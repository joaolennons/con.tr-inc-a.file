﻿using MediatR;
using System;

namespace Domain.Notifications
{
    public class PresenceConfirmed : PresenceChanged, INotification
    {
        private PresenceConfirmed(Guid barbecueId, decimal value) : base(barbecueId, value) { }

        public static PresenceConfirmed Notify(Guid barbecueId, decimal value)
         => new PresenceConfirmed(barbecueId, value);
    }
}
