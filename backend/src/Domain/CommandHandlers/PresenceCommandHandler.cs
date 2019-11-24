using Domain.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Write;
using Write.Pocos;

namespace Domain.CommandHandlers
{
    public class PresenceCommandHandler : IRequestHandler<PresenceOnBarbecue>,
        IRequestHandler<UpdatePresenceOnBarbecue>,
        IRequestHandler<CancelPresenceOnBarbecue>
    {
        private readonly IMediator _mediator;
        private readonly WriteContext _context;
        
        public PresenceCommandHandler(WriteContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(PresenceOnBarbecue request, CancellationToken cancellationToken)
        {
            var barbecue = await _context.Barbecues
               .Include(o => o.Presences)
               .FirstOrDefaultAsync(o => o.Id == request.BarbecueId);

            if (!barbecue.Presences.Any(o => o.ParticipantId == request.ParticipantId))
            {
                barbecue.UpdateDate = DateTime.Now;
                _context.Presence.Add(new Presence(request.Value, request.BarbecueId, request.ParticipantId));
                await _context.SaveChangesAsync();
                await _mediator.Publish(PresenceConfirmed.Notify(request.BarbecueId, request.Value));
            }

            return Unit.Value;
        }

        public async Task<Unit> Handle(CancelPresenceOnBarbecue request, CancellationToken cancellationToken)
        {
            var presence = _context.Presence
                .Include(o => o.Barbecue)
                .FirstOrDefault(o => o.ParticipantId == request.ParticipantId && o.BarbecueId == request.BarbecueId);

            if (presence != null)
            {
                presence.Barbecue.UpdateDate = DateTime.Now;
                _context.Entry(presence).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                await _mediator.Publish(PresenceCanceled.Notify(request.BarbecueId, presence.Value));
            }

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdatePresenceOnBarbecue request, CancellationToken cancellationToken)
        {
            var presence = _context.Presence
                .Include(o => o.Barbecue)
                .FirstOrDefault(o => o.ParticipantId == request.ParticipantId && o.BarbecueId == request.BarbecueId);

            if (presence != null)
            {
                presence.Barbecue.UpdateDate = DateTime.Now;
                var oldValue = presence.Value;
                presence.Value = request.Value;
                await _context.SaveChangesAsync();
                await _mediator.Publish(PresenceUpdated.Notify(request.BarbecueId, oldValue, presence.Value));
            }

            return Unit.Value;
        }
    }
}
