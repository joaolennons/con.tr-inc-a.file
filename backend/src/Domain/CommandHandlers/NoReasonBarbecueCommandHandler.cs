using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Write;
using Write.Pocos;

namespace Domain.CommandHandlers
{
    public class NoReasonBarbecueCommandHandler : IRequestHandler<NoReasonBarbecue, Guid>
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
    }
}
