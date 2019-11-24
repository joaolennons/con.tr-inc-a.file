using System;

namespace Domain.Notifications
{
    public class PresenceCanceled : PresenceChanged
    {
        private PresenceCanceled(Guid barbecueId, decimal value, bool paid) : base(barbecueId, value)
        {
            Paid = paid;
        }

        public bool Paid { get; }

        public static PresenceCanceled Notify(Guid barbecueId, decimal value, bool paid)
         => new PresenceCanceled(barbecueId, value, paid);
    }
}
