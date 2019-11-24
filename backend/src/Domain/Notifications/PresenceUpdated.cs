using System;

namespace Domain.Notifications
{
    public class PresenceUpdated : PresenceChanged
    {
        private PresenceUpdated(Guid barbecueId, decimal oldValue, decimal value) : base(barbecueId, value)
        {
            OldValue = oldValue;
        }

        public decimal OldValue { get; }

        public static PresenceUpdated Notify(Guid barbecueId, decimal oldValue, decimal value)
         => new PresenceUpdated(barbecueId, oldValue, value);
    }
}
