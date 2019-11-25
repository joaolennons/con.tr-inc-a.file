using Domain.NotificationHandlers;
using Domain.Notifications;
using Moq;
using System;
using System.Collections.Generic;
using Write.Pocos;
using Write.Repositories;
using Xunit;

namespace Domain.Test.NotificationHandlers
{
    public class PresenceNotificationHandlerTest
    {
        private readonly Mock<IBarbecueRepository> _context;
        private readonly Mock<INotificationHandler> _notifications;
        private readonly PresenceNotificationHandler _handler;

        public PresenceNotificationHandlerTest()
        {
            _context = new Mock<IBarbecueRepository>();
            _notifications = new Mock<INotificationHandler>();
            _handler = new PresenceNotificationHandler(_notifications.Object, _context.Object);
        }

        [Fact]
        public void Should_UpdateBarbecueValues_When_PresenceIsCanceled()
        {
            var id = Guid.NewGuid();
            var participantId = Guid.NewGuid();
            var barbecue = new Barbecue
            {
                Id = id,
                Presences = new List<Presence>
                {
                    new Presence
                    {
                        ParticipantId = participantId
                    }
                }
            };

            _context.Setup(o => o.GetAll()).Returns(new AsyncEnumerable<Barbecue>(new List<Barbecue> { barbecue }));
            _context.Setup(o => o.Commit());
            _handler.Handle(PresenceCanceled.Notify(Guid.Empty, 12, true), default).GetAwaiter().GetResult();
            Mock.VerifyAll();
        }

        [Fact]
        public void Should_UpdateBarbecueValues_When_PresenceIsConfirmed()
        {
            var id = Guid.NewGuid();
            var participantId = Guid.NewGuid();
            var barbecue = new Barbecue
            {
                Id = id,
                Presences = new List<Presence>
                {
                    new Presence
                    {
                        ParticipantId = participantId
                    }
                }
            };

            _context.Setup(o => o.GetAll()).Returns(new AsyncEnumerable<Barbecue>(new List<Barbecue> { barbecue }));
            _context.Setup(o => o.Commit());
            _handler.Handle(PresenceConfirmed.Notify(Guid.Empty, 12), default).GetAwaiter().GetResult();
            Mock.VerifyAll();
        }

        [Fact]
        public void Should_UpdateBarbecueValues_When_PresenceIsUpdated()
        {
            var id = Guid.NewGuid();
            var participantId = Guid.NewGuid();
            var barbecue = new Barbecue
            {
                Id = id,
                Presences = new List<Presence>
                {
                    new Presence
                    {
                        ParticipantId = participantId
                    }
                }
            };

            _context.Setup(o => o.GetAll()).Returns(new AsyncEnumerable<Barbecue>(new List<Barbecue> { barbecue }));
            _context.Setup(o => o.Commit());
            _handler.Handle(PresenceUpdated.Notify(Guid.Empty, 10, 20, true), default).GetAwaiter().GetResult();
            Mock.VerifyAll();
        }

        [Fact]
        public void Should_UpdateBarbecueValues_When_PaymentIsUpdated()
        {
            var id = Guid.NewGuid();
            var participantId = Guid.NewGuid();
            var barbecue = new Barbecue
            {
                Id = id,
                Presences = new List<Presence>
                {
                    new Presence
                    {
                        ParticipantId = participantId
                    }
                }
            };

            _context.Setup(o => o.GetAll()).Returns(new AsyncEnumerable<Barbecue>(new List<Barbecue> { barbecue }));
            _context.Setup(o => o.Commit());
            _handler.Handle(PaymentUpdated.Notify(Guid.Empty, 20, true), default).GetAwaiter().GetResult();
            Mock.VerifyAll();
        }
    }
}
