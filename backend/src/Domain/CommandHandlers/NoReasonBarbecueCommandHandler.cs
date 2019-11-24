using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Write;
using Write.Pocos;
using Write.Repositories;

namespace Domain.CommandHandlers
{
    public class NoReasonBarbecueCommandHandler : IRequestHandler<CreateNoReasonBarbecue, Guid>,
        IRequestHandler<NoReasonBarbecueUpdate, DateTime>,
        IRequestHandler<CancelBarbecue>
    {
        private readonly IBarbecueRepository _context;
        private readonly IMapper _mapper;
        public NoReasonBarbecueCommandHandler(IBarbecueRepository context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Guid> Handle(CreateNoReasonBarbecue request, CancellationToken cancellationToken)
        {
            var bbq = _mapper.Map<Barbecue>(request);
            _context.Add(bbq);
            await _context.Commit();
            return bbq.Id;
        }

        public async Task<DateTime> Handle(NoReasonBarbecueUpdate request, CancellationToken cancellationToken)
        {
            var bbq = await _context.Find(request.Id);
            bbq.Date = request.Date;
            bbq.Description = request.Description;
            bbq.Observation = request.Observation;
            bbq.UpdateDate = DateTime.Now;
            await _context.Commit();
            return bbq.UpdateDate.Value;
        }

        public async Task<Unit> Handle(CancelBarbecue request, CancellationToken cancellationToken)
        {
            await _context.Delete(request.BarbecueId);
            await _context.Commit();
            return Unit.Value;
        }
    }
}
