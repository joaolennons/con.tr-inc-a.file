using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Write;

namespace Domain.CommandHandlers
{
    public class PresenceCommandHandler// : IRequestHandler<NoReasonBarbecue>
    {
        private readonly WriteContext _context;
        
        public PresenceCommandHandler(WriteContext context)
        {
            _context = context;
        }
        //public Task<Unit> Handle(NoReasonBarbecue request, CancellationToken cancellationToken)
        //{
        //    _context.Barbecues
        //        .Include(o => o.Presences)
        //        .FirstOrDefaultAsync(o => o.Id === );
        //}
    }
}
