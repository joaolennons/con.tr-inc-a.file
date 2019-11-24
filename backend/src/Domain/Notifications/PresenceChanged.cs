using MediatR;
using System;

namespace Domain.Notifications
{
    public abstract class PresenceChanged : INotification
    {
        public Guid BarbecueId { get; }
        public decimal Value { get; }
        protected PresenceChanged(Guid barbecueId, decimal value)
        {
            BarbecueId = barbecueId;
            Value = value;
        }
    }
}
