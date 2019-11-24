using System;
using static Domain.CancelBarbecue;
using static Domain.CancelPresenceOnBarbecue;
using static Domain.CreateNoReasonBarbecue;
using static Domain.NoReasonBarbecueUpdate;
using static Domain.PresenceOnBarbecue;
using static Domain.UpdatePayment;
using static Domain.UpdatePresenceOnBarbecue;

namespace Domain
{
    public class EventOrganizer
    {
        public static BarbecueBuilder ScheduleNewBarbecue => new BarbecueBuilder();
        public static BarbecueUpdateBuilder UpdateBarbecue(Guid id) => new BarbecueUpdateBuilder(id);
        public static PresenceBuilder ConfirmPresence => new PresenceBuilder();
        public static UpdatePresenceBuilder UpdatePresence => new UpdatePresenceBuilder();
        public static PaymentBuilder UpdatePayment => new PaymentBuilder();
        public static CancelPresenceBuilder CancelPresence => new CancelPresenceBuilder();
        public static CancelBarbecueBuilder CancelBarbecue(Guid id) => new CancelBarbecueBuilder(id);
    }
}