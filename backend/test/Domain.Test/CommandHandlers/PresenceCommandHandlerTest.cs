using Domain.CommandHandlers;
using Domain.Notifications;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using Write.Pocos;
using Write.Repositories;
using Xunit;

namespace Domain.Test.CommandHandlers
{
    public class PresenceCommandHandlerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IPresenceRepository> _presences;
        private readonly Mock<INotificationHandler> _notificationHandler;
        private readonly Mock<IBarbecueRepository> _barbecues;
        private readonly PresenceCommandHandler _handler;

        public PresenceCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _presences = new Mock<IPresenceRepository>();
            _barbecues = new Mock<IBarbecueRepository>();
            _notificationHandler = new Mock<INotificationHandler>();

            _handler = new PresenceCommandHandler(_notificationHandler.Object, _presences.Object, _barbecues.Object, _mediator.Object);
        }

        [Fact]
        public void Should_ByPassConfirmPresence_When_BarbecueNotFound()
        {
            var id = Guid.NewGuid();
            _barbecues.Setup(o => o.GetAll()).Returns(new AsyncEnumerable<Barbecue>(new List<Barbecue>()));
            var result = _handler.Handle(new PresenceOnBarbecue(), default).Result;

            Assert.Equal(Unit.Value, result);
            Mock.VerifyAll();
        }

        [Fact]
        public void Should_ConfirmPresence_When_HandlerIsActivated()
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

            _barbecues.Setup(o => o.GetAll()).Returns(new AsyncEnumerable<Barbecue>(new List<Barbecue> { barbecue }));
            _presences.Setup(o => o.Add(It.IsAny<Presence>()));
            _presences.Setup(o => o.Commit());
            _mediator.Setup(o => o.Publish(It.IsAny<PresenceConfirmed>(), default));
            var result = _handler.Handle(new PresenceOnBarbecue(), default).Result;

            Assert.Equal(Unit.Value, result);
            Mock.VerifyAll();
        }

        [Fact]
        public void Should_ByPassCancelPresence_When_PresenceNotFound()
        {
            var id = Guid.NewGuid();
            _barbecues.Setup(o => o.GetAll()).Returns(new AsyncEnumerable<Barbecue>(new List<Barbecue>()));
            var result = _handler.Handle(new CancelPresenceOnBarbecue(), default).Result;

            Assert.Equal(Unit.Value, result);
            Mock.VerifyAll();
        }

        [Fact]
        public void Should_CancelPresence_When_HandlerIsActivated()
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

            _barbecues.Setup(o => o.GetAll()).Returns(new AsyncEnumerable<Barbecue>(new List<Barbecue> { barbecue }));
            _presences.Setup(o => o.Delete(It.IsAny<Presence>()));
            _presences.Setup(o => o.Commit());
            _mediator.Setup(o => o.Publish(It.IsAny<PresenceCanceled>(), default));
            var result = _handler.Handle(new CancelPresenceOnBarbecue(), default).Result;

            Assert.Equal(Unit.Value, result);
            Mock.VerifyAll();
        }

        [Fact]
        public void Should_ByPassUpdatePresence_When_PresenceNotFound()
        {
            var id = Guid.NewGuid();
            _barbecues.Setup(o => o.GetAll()).Returns(new AsyncEnumerable<Barbecue>(new List<Barbecue>()));
            var result = _handler.Handle(new UpdatePresenceOnBarbecue(), default).Result;

            Assert.Equal(Unit.Value, result);
            Mock.VerifyAll();
        }

        [Fact]
        public void Should_UpdatePresence_When_HandlerIsActivated()
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

            _barbecues.Setup(o => o.GetAll()).Returns(new AsyncEnumerable<Barbecue>(new List<Barbecue> { barbecue }));
            _presences.Setup(o => o.Commit());
            _mediator.Setup(o => o.Publish(It.IsAny<PresenceUpdated>(), default));
            var result = _handler.Handle(new UpdatePresenceOnBarbecue(), default).Result;

            Assert.Equal(Unit.Value, result);
            Mock.VerifyAll();
        }

        [Fact]
        public void Should_ByPassUpdatePayment_When_PresenceNotFound()
        {
            var id = Guid.NewGuid();
            _barbecues.Setup(o => o.GetAll()).Returns(new AsyncEnumerable<Barbecue>(new List<Barbecue>()));
            var result = _handler.Handle(new UpdatePresenceOnBarbecue(), default).Result;

            Assert.Equal(Unit.Value, result);
            Mock.VerifyAll();
        }

        [Fact]
        public void Should_UpdatePayment_When_HandlerIsActivated()
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

            _barbecues.Setup(o => o.GetAll()).Returns(new AsyncEnumerable<Barbecue>(new List<Barbecue> { barbecue }));
            _presences.Setup(o => o.Commit());
            _mediator.Setup(o => o.Publish(It.IsAny<PaymentUpdated>(), default));
            var result = _handler.Handle(new UpdatePayment(), default).Result;

            Assert.Equal(Unit.Value, result);
            Mock.VerifyAll();
        }
    }
}
