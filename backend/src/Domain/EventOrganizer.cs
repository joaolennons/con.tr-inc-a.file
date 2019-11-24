﻿using System;
using static Domain.CancelPresenceOnBarbecue;
using static Domain.NoReasonBarbecue;
using static Domain.NoReasonBarbecueUpdate;
using static Domain.PresenceOnBarbecue;
using static Domain.UpdatePresenceOnBarbecue;

namespace Domain
{
    public class EventOrganizer
    {
        public static BarbecueBuilder ScheduleNewBarbecue => new BarbecueBuilder();
        public static BarbecueUpdateBuilder UpdateBarbecue(Guid id) => new BarbecueUpdateBuilder(id);
        public static PresenceBuilder ConfirmPresence => new PresenceBuilder();
        public static UpdatePresenceBuilder UpdatePresence => new UpdatePresenceBuilder();
        public static CancelPresenceBuilder CancelPresence => new CancelPresenceBuilder();
    }
}