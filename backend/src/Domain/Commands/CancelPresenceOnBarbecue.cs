using MediatR;
using System;

namespace Domain
{
    public class CancelPresenceOnBarbecue : IRequest
    {
        public Guid ParticipantId { get; private set; }
        public Guid BarbecueId { get; private set; }
        public bool Paid { get; private set; }

        public class CancelPresenceBuilder
        {
            private readonly CancelPresenceOnBarbecue _presence;
            public CancelPresenceBuilder()
            {
                _presence = new CancelPresenceOnBarbecue();
            }

            public CancelPresenceBuilder Of(Guid participantId)
            {
                _presence.ParticipantId = participantId;
                return this;
            }

            public CancelPresenceBuilder On(Guid barbecueId)
            {
                _presence.BarbecueId = barbecueId;
                return this;
            }

            public CancelPresenceBuilder WasPaid(bool wasPaid)
            {
                _presence.Paid = wasPaid;
                return this;
            }

            public CancelPresenceOnBarbecue Please()
            {
                return _presence;
            }
        }        
    }
}