using MediatR;
using System;

namespace Domain
{
    public class PresenceOnBarbecue : IRequest
    {
        public Guid ParticipantId { get; private set; }
        public Guid BarbecueId { get; private set; }
        public decimal Value { get; private set; }

        public class PresenceBuilder
        {
            private readonly PresenceOnBarbecue _presence;
            public PresenceBuilder()
            {
                _presence = new PresenceOnBarbecue();
            }

            public PresenceBuilder Of(Guid participantId)
            {
                _presence.ParticipantId = participantId;
                return this;
            }

            public PresenceBuilder On(Guid barbecueId)
            {
                _presence.BarbecueId = barbecueId;
                return this;
            }

            public PresenceBuilder PayingBy(Drinking optingTo)
            {
                _presence.Value = optingTo == Drinking.Yes ? DrinkingOptionValue.Instance.Drinking : DrinkingOptionValue.Instance.NotDrinking;
                return this;
            }

            public PresenceOnBarbecue Please() => _presence;
        }        
    }
}