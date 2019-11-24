using MediatR;
using System;

namespace Domain
{
    public class UpdatePayment : IRequest
    {
        public Guid ParticipantId { get; private set; }
        public Guid BarbecueId { get; private set; }
        public bool Paid { get; private set; }

        public class PaymentBuilder
        {
            private readonly UpdatePayment _presence;
            public PaymentBuilder()
            {
                _presence = new UpdatePayment();
            }

            public PaymentBuilder Of(Guid participantId)
            {
                _presence.ParticipantId = participantId;
                return this;
            }

            public PaymentBuilder On(Guid barbecueId)
            {
                _presence.BarbecueId = barbecueId;
                return this;
            }

            public PaymentBuilder SetPaid(bool paid)
            {
                _presence.Paid = paid;
                return this;
            }

            public UpdatePayment Please() => _presence;
        }
    }
}
