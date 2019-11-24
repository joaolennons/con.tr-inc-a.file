using System;

namespace Domain.Notifications
{
    public class PaymentUpdated : PresenceChanged
    {
        private PaymentUpdated(Guid barbecueId, decimal value, bool paid) : base(barbecueId, value)
        {
            Paid = paid;
        }

        public bool Paid { get; }

        public static PaymentUpdated Notify(Guid barbecueId, decimal value, bool paid)
         => new PaymentUpdated(barbecueId, value, paid);
    }
}
