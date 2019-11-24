using MediatR;
using System;

namespace Domain
{
    public class CancelBarbecue : IRequest
    {
        public Guid BarbecueId { get; }
        private CancelBarbecue(Guid id)
        {
            BarbecueId = id;
        }
        public class CancelBarbecueBuilder
        {
            private readonly CancelBarbecue _barbecue;
            public CancelBarbecueBuilder(Guid id)
            {
                _barbecue = new CancelBarbecue(id);
            }

            public CancelBarbecue Please() => _barbecue;
        }
    }
}
