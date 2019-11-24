using MediatR;
using System;

namespace Domain
{
    public class UpdateNoReasonBarbecue : IRequest<DateTime>
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }
        public string Observation { get; private set; }
        private UpdateNoReasonBarbecue(Guid id)
        {
            Id = id;
        }
        public class BarbecueUpdateBuilder
        {
            private readonly UpdateNoReasonBarbecue _bbq;
            public BarbecueUpdateBuilder(Guid id)
            {
                _bbq = new UpdateNoReasonBarbecue(id);
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

            public UpdateNoReasonBarbecue Please() => _bbq;
        }
    }
}