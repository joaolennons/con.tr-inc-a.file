using MediatR;
using System;

namespace Domain
{
    public class NoReasonBarbecueUpdate : IRequest<Guid>
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }
        public string Observation { get; private set; }
        private NoReasonBarbecueUpdate(Guid id)
        {
            Id = id;
        }
        public class BarbecueUpdateBuilder
        {
            private readonly NoReasonBarbecueUpdate _bbq;
            public BarbecueUpdateBuilder(Guid id)
            {
                _bbq = new NoReasonBarbecueUpdate(id);
            }

            public BarbecueUpdateBuilder Named(string description)
            {
                _bbq.Description = description;
                return this;
            }

            public BarbecueUpdateBuilder At(DateTime date)
            {
                _bbq.Date = date;
                return this;
            }

            public BarbecueUpdateBuilder WithObservation(string observation)
            {
                _bbq.Observation = observation;
                return this;
            }

            public NoReasonBarbecueUpdate Please() => _bbq;
        }
    }
}