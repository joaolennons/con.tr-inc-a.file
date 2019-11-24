using System.Threading;
using System.Threading.Tasks;
using Domain.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Write;

namespace Domain.NotificationHandlers
{
    public class PresenceNotificationHandler : INotificationHandler<PresenceConfirmed>, INotificationHandler<PresenceCanceled>
    {
        private readonly WriteContext _context;
        public PresenceNotificationHandler(WriteContext context)
        {
            _context = context;
        }
        public async Task Handle(PresenceCanceled notification, CancellationToken cancellationToken)
            => await UpdateBarbecue(notification, PresenceChangedType.Canceled);

        public async Task Handle(PresenceConfirmed notification, CancellationToken cancellationToken)
            => await UpdateBarbecue(notification, PresenceChangedType.Confirmed);

        private async Task UpdateBarbecue(PresenceChanged notification, PresenceChangedType changeType)
        {
            var bbq = await _context.Barbecues
                    .FirstOrDefaultAsync(o => o.Id == notification.BarbecueId);

            if (bbq == null)
                return;

            bbq.TotalAmount += changeType == PresenceChangedType.Confirmed ? notification.Value : -notification.Value;
            bbq.TotalParticipants+= changeType == PresenceChangedType.Confirmed ? 1 : -1;
            await _context.SaveChangesAsync();
        }
    }

    internal enum PresenceChangedType
    {
        Confirmed,
        Canceled
    }
}
