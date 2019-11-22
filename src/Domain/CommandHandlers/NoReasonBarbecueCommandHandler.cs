using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Write;
using Write.Pocos;

namespace Domain.CommandHandlers
{
    public class NoReasonBarbecueCommandHandler : IRequestHandler<NoReasonBarbecue>
    {
        private readonly WriteContext _context;
        private readonly IMapper _mapper;
        public NoReasonBarbecueCommandHandler(WriteContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(NoReasonBarbecue request, CancellationToken cancellationToken)
        {
            _context.Barbecues.Add(_mapper.Map<Barbecue>(request));
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
