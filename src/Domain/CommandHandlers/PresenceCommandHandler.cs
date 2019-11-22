﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Write;
using Write.Pocos;

namespace Domain.CommandHandlers
{
    public class PresenceCommandHandler : IRequestHandler<PresenceOnBarbecue>, IRequestHandler<CancelPresenceOnBarbecue>
    {
        private readonly WriteContext _context;
        
        public PresenceCommandHandler(WriteContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(PresenceOnBarbecue request, CancellationToken cancellationToken)
        {
            var barbecue = await _context.Barbecues
               .Include(o => o.Presences)
               .FirstOrDefaultAsync(o => o.Id == request.BarbecueId);

            if (!barbecue.Presences.Any(o => o.ParticipantId == request.ParticipantId))
            {
                _context.Presence.Add(new Presence(request.Value, request.BarbecueId, request.ParticipantId));
                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }

        public async Task<Unit> Handle(CancelPresenceOnBarbecue request, CancellationToken cancellationToken)
        {
            var presence = _context.Presence
                .FirstOrDefault(o => o.ParticipantId == request.ParticipantId && o.BarbecueId == request.BarbecueId);

            if (presence != null)
            {
                _context.Entry(presence).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
