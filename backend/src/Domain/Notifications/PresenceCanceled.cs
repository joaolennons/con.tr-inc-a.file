using System;

namespace Domain.Notifications
{
    public class PresenceCanceled : PresenceChanged
    {
        private PresenceCanceled(Guid barbecueId, decimal value) : base(barbecueId, value){ }

        public static PresenceCanceled Notify(Guid barbecueId, decimal value)
         => new PresenceCanceled(barbecueId, value);
    }
}
