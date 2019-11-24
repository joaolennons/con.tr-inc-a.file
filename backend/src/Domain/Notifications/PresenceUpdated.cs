using System;

namespace Domain.Notifications
{
    public class PresenceUpdated : PresenceChanged
    {
        private PresenceUpdated(Guid barbecueId, decimal oldValue, decimal value, bool paid) : base(barbecueId, value)
        {
            OldValue = oldValue;
            Paid = paid;
        }

        public decimal OldValue { get; }
        public bool Paid { get; }

        public static PresenceUpdated Notify(Guid barbecueId, decimal oldValue, decimal value, bool paid)
         => new PresenceUpdated(barbecueId, oldValue, value, paid);
    }
}
