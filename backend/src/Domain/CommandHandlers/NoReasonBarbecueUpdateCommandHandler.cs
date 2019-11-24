using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Write;
using Write.Pocos;

namespace Domain.CommandHandlers
{
    public class NoReasonBarbecueUpdateCommandHandler : IRequestHandler<NoReasonBarbecueUpdate, Guid>
    {
        private readonly WriteContext _context;
        private readonly IMapper _mapper;
        public NoReasonBarbecueUpdateCommandHandler(WriteContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Guid> Handle(NoReasonBarbecueUpdate request, CancellationToken cancellationToken)
        {
            var bbq = await _context.Barbecues.FindAsync(request.Id);
            bbq.Date = request.Date;
            bbq.Description = request.Description;
            bbq.Observation = request.Observation;
            await _context.SaveChangesAsync();
            return bbq.Id;
        }
    }
}
