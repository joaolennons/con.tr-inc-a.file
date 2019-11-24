using MediatR;
using System;

namespace Domain
{
    public class UpdatePresenceOnBarbecue : IRequest
    {
        public Guid ParticipantId { get; private set; }
        public Guid BarbecueId { get; private set; }
        public decimal Value { get; private set; }
        public bool Paid { get; private set; }

        public class UpdatePresenceBuilder
        {
            private readonly UpdatePresenceOnBarbecue _presence;
            public UpdatePresenceBuilder()
            {
                _presence = new UpdatePresenceOnBarbecue();
            }

            public UpdatePresenceBuilder Of(Guid participantId)
            {
                _presence.ParticipantId = participantId;
                return this;
            }

            public UpdatePresenceBuilder On(Guid barbecueId)
            {
                _presence.BarbecueId = barbecueId;
                return this;
            }

            public UpdatePresenceBuilder PayingBy(Drinking optingTo)
            {
                _presence.Value = optingTo == Drinking.Yes ? DrinkingOptionValue.Instance.Drinking : DrinkingOptionValue.Instance.NotDrinking;
                return this;
            }

            public UpdatePresenceBuilder IsPaid(bool paid)
            {
                _presence.Paid = paid;
                return this;
            }

            public UpdatePresenceOnBarbecue Please() => _presence;
        }        
    }
}