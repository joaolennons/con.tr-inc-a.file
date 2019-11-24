using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Write;
using Write.Pocos;

namespace Domain.CommandHandlers
{
    public class NoReasonBarbecueCommandHandler : IRequestHandler<NoReasonBarbecue, Guid>,
        IRequestHandler<NoReasonBarbecueUpdate, DateTime>,
        IRequestHandler<CancelBarbecue>
    {
        private readonly WriteContext _context;
        private readonly IMapper _mapper;
        public NoReasonBarbecueCommandHandler(WriteContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Guid> Handle(NoReasonBarbecue request, CancellationToken cancellationToken)
        {
            var bbq = _mapper.Map<Barbecue>(request);
            _context.Barbecues.Add(bbq);
            await _context.SaveChangesAsync();
            return bbq.Id;
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

        public async Task<Unit> Handle(CancelBarbecue request, CancellationToken cancellationToken)
        {
            var bbq = await _context.Barbecues.FindAsync(request.BarbecueId);
            _context.Entry(bbq).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
