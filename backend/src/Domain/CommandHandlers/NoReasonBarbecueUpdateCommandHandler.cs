using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Write;

namespace Domain.CommandHandlers
{
    public class NoReasonBarbecueUpdateCommandHandler : IRequestHandler<NoReasonBarbecueUpdate, DateTime>
    {
        private readonly WriteContext _context;
        public NoReasonBarbecueUpdateCommandHandler(WriteContext context)
        {
            _context = context;
        }

        public async Task<DateTime> Handle(NoReasonBarbecueUpdate request, CancellationToken cancellationToken)
        {
            var bbq = await _context.Barbecues.FindAsync(request.Id);
            bbq.Date = request.Date;
            bbq.Description = request.Description;
            bbq.Observation = request.Observation;
            bbq.UpdateDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return bbq.UpdateDate.Value;
        }
    }
}
