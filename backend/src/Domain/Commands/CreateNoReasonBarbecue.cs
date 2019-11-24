using MediatR;
using System;

namespace Domain
{
    public class CreateNoReasonBarbecue : IRequest<Guid>
    {
        public DateTime Date { get; protected set; }
        public string Description { get; protected set; }
        public string Observation { get; protected set; }

        public class BarbecueBuilder
        {
            private readonly CreateNoReasonBarbecue _bbq;
            public BarbecueBuilder()
            {
                _bbq = new CreateNoReasonBarbecue();
            }

            public BarbecueBuilder Named(string description)
            {
                _bbq.Description = description;
                return this;
            }

            public BarbecueBuilder At(DateTime date)
            {
                _bbq.Date = date;
                return this;
            }

            public BarbecueBuilder WithObservation(string observation)
            {
                _bbq.Observation = observation;
                return this;
            }

            public CreateNoReasonBarbecue Please() => _bbq;
        }
    }
}