﻿using static Domain.NoReasonBarbecue;
using static Domain.PresenceOnBarbecue;

namespace Domain
{
    public class EventOrganizer
    {
        public static BarbecueBuilder ScheduleNewBarbecue => new BarbecueBuilder();
        public static PresenceBuilder ConfirmPresence => new PresenceBuilder();
    }
}