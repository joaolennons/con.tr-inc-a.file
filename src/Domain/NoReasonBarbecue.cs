using MediatR;
using System;

namespace Domain
{
    public class NoReasonBarbecue : IRequest
    {
        public Guid Id { get; protected set; }
        public DateTime Date { get; protected set; }
        public string Description { get; protected set; }
        public string Observation { get; protected set; }

        public class BarbecueBuilder
        {
            private readonly NoReasonBarbecue _bbq;
            public BarbecueBuilder()
            {
                _bbq = new NoReasonBarbecue();
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

            public NoReasonBarbecue Please() => _bbq;
        }
    }
}