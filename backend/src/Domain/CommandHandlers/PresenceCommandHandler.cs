﻿using Domain.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Write.Pocos;
using Write.Repositories;

namespace Domain.CommandHandlers
{
    public class PresenceCommandHandler : IRequestHandler<PresenceOnBarbecue>,
        IRequestHandler<UpdatePresenceOnBarbecue>,
        IRequestHandler<CancelPresenceOnBarbecue>,
        IRequestHandler<UpdatePayment>
    {
        private readonly IMediator _mediator;
        private readonly IPresenceRepository _presences;
        private readonly IBarbecueRepository _barbecues;
        private readonly INotificationHandler _notifications;

        public PresenceCommandHandler(INotificationHandler notifications, IPresenceRepository presences, IBarbecueRepository barbecues, IMediator mediator)
        {
            _presences = presences;
            _barbecues = barbecues;
            _mediator = mediator;
            _notifications = notifications;
        }

        public async Task<Unit> Handle(PresenceOnBarbecue request, CancellationToken cancellationToken)
        {
            var barbecue = await _barbecues.GetAll()
               .Include(o => o.Presences)
               .FirstOrDefaultAsync(o => o.Id == request.BarbecueId);

            if (barbecue == null)
            {
                _notifications.AddNotification(AppConsts.BarbecueNotFound);
                return Unit.Value;
            }

            if (!barbecue.Presences.Any(o => o.ParticipantId == request.ParticipantId))
            {
                barbecue.UpdateDate = DateTime.Now;
                _presences.Add(new Presence(request.Value, request.BarbecueId, request.ParticipantId));
                await _presences.Commit();
                await _mediator.Publish(PresenceConfirmed.Notify(request.BarbecueId, request.Value));
            }

            return Unit.Value;
        }

        public async Task<Unit> Handle(CancelPresenceOnBarbecue request, CancellationToken cancellationToken)
        {
            var presence = _presences.GetAll()
                .Include(o => o.Barbecue)
                .FirstOrDefault(o => o.ParticipantId == request.ParticipantId && o.BarbecueId == request.BarbecueId);

            if (presence == null)
            {
                _notifications.AddNotification(AppConsts.PresenceNotFound);
                return Unit.Value;
            }

            presence.Barbecue.UpdateDate = DateTime.Now;
            _presences.Delete(presence);
            await _presences.Commit();
            await _mediator.Publish(PresenceCanceled.Notify(request.BarbecueId, presence.Value, request.Paid));


            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdatePresenceOnBarbecue request, CancellationToken cancellationToken)
        {
            var presence = _presences.GetAll()
                .Include(o => o.Barbecue)
                .FirstOrDefault(o => o.ParticipantId == request.ParticipantId && o.BarbecueId == request.BarbecueId);

            if (presence == null)
            {
                _notifications.AddNotification(AppConsts.PresenceNotFound);
                return Unit.Value;
            }

            presence.Barbecue.UpdateDate = DateTime.Now;
            var oldValue = presence.Value;
            presence.Value = request.Value;
            await _presences.Commit();
            await _mediator.Publish(PresenceUpdated.Notify(request.BarbecueId, oldValue, presence.Value, request.Paid));


            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdatePayment request, CancellationToken cancellationToken)
        {
            var presence = _presences.GetAll()
                .Include(o => o.Barbecue)
                .FirstOrDefault(o => o.ParticipantId == request.ParticipantId && o.BarbecueId == request.BarbecueId);

            if (presence == null)
            {
                _notifications.AddNotification(AppConsts.PresenceNotFound);
                return Unit.Value;
            }
            
                presence.Barbecue.UpdateDate = DateTime.Now;
                presence.Paid = request.Paid;
                await _presences.Commit();
                await _mediator.Publish(PaymentUpdated.Notify(request.BarbecueId, presence.Value, request.Paid));
            

            return Unit.Value;
        }
    }
}
