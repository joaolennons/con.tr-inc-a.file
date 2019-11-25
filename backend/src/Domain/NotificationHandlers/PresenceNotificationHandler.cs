using System.Threading;
using System.Threading.Tasks;
using Domain.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Write;
using Write.Repositories;

namespace Domain.NotificationHandlers
{
    public class PresenceNotificationHandler : INotificationHandler<PresenceConfirmed>,
        INotificationHandler<PresenceUpdated>,
        INotificationHandler<PresenceCanceled>,
        INotificationHandler<PaymentUpdated>
    {
        private readonly IBarbecueRepository _context;
        private readonly INotificationHandler _notifications;

        public PresenceNotificationHandler(INotificationHandler notifications, IBarbecueRepository context)
        {
            _context = context;
            _notifications = notifications;
        }
        public async Task Handle(PresenceCanceled notification, CancellationToken cancellationToken)
            => await UpdateBarbecue(notification, PresenceChangedType.Canceled, notification.Paid);

        public async Task Handle(PresenceConfirmed notification, CancellationToken cancellationToken)
            => await UpdateBarbecue(notification, PresenceChangedType.Confirmed);

        public async Task Handle(PresenceUpdated notification, CancellationToken cancellationToken)
        {
            var bbq = await _context.GetAll()
                   .FirstOrDefaultAsync(o => o.Id == notification.BarbecueId);

            if (bbq == null)
            {
                _notifications.AddNotification(AppConsts.BarbecueNotFound);
                return;
            }

            bbq.TotalAmount = bbq.TotalAmount - notification.OldValue + notification.Value;

            if (notification.Paid) 
                bbq.TotalRaised = bbq.TotalRaised - notification.OldValue + notification.Value;

            await _context.Commit();
        }

        public async Task Handle(PaymentUpdated notification, CancellationToken cancellationToken)
        {
            var bbq = await _context.GetAll()
                   .FirstOrDefaultAsync(o => o.Id == notification.BarbecueId);

            if (bbq == null)
            {
                _notifications.AddNotification(AppConsts.BarbecueNotFound);
                return;
            }

            bbq.TotalRaised += notification.Paid ? notification.Value : -notification.Value;
            await _context.Commit();
        }

        private async Task UpdateBarbecue(PresenceChanged notification, PresenceChangedType changeType, bool decreaseRaised = false)
        {
            var bbq = await _context.GetAll()
                    .FirstOrDefaultAsync(o => o.Id == notification.BarbecueId);

            if (bbq == null)
            {
                _notifications.AddNotification(AppConsts.BarbecueNotFound);
                return;
            }

            bbq.TotalAmount += changeType == PresenceChangedType.Confirmed ? notification.Value : -notification.Value;
            bbq.TotalParticipants += changeType == PresenceChangedType.Confirmed ? 1 : -1;

            if (decreaseRaised)
                bbq.TotalRaised -= notification.Value;

            await _context.Commit();
        }
    }

    internal enum PresenceChangedType
    {
        Confirmed,
        Canceled
    }
}
