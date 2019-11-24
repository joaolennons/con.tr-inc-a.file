using AutoMapper;
using Domain.CommandHandlers;
using MediatR;
using Moq;
using System;
using System.Threading.Tasks;
using Write.Pocos;
using Write.Repositories;
using Xunit;

namespace Domain.Test.CommandHandlers
{
    public class NoReasonBarbecueCommandHandlerTest
    {
        private readonly NoReasonBarbecueCommandHandler _handler;
        private readonly Mock<IBarbecueRepository> _repository;
        private readonly Mock<IMapper> _mapper;
        public NoReasonBarbecueCommandHandlerTest()
        {
            _repository = new Mock<IBarbecueRepository>();
            _mapper = new Mock<IMapper>();

            _handler = new NoReasonBarbecueCommandHandler(_repository.Object, _mapper.Object);
        }

        [Fact]
        public void Should_CreateNewBarbecue_When_HandlerIsActivated()
        {
            var id = Guid.NewGuid();
            _mapper.Setup(o => o.Map<Barbecue>(It.IsAny<CreateNoReasonBarbecue>())).Returns(new Barbecue { Id = id });
            _repository.Setup(o => o.Add(It.IsAny<Barbecue>())).Callback(() => { });
            _repository.Setup(o => o.Commit()).Callback(() => { });
            var result = _handler.Handle(new CreateNoReasonBarbecue(), default).Result;
            Mock.VerifyAll();
            Assert.Equal(id, result);
        }

        [Fact]
        public void Should_UpdateBarbecue_When_HandlerIsActivated()
        {
            _repository.Setup(o => o.Find(It.IsAny<Guid>())).Returns(Task.FromResult(new Barbecue()));
            _repository.Setup(o => o.Commit()).Callback(() => { });
            var result = _handler.Handle(new NoReasonBarbecueUpdate.BarbecueUpdateBuilder(Guid.NewGuid()).Please(), default).Result;
            Mock.VerifyAll();
            Assert.Equal(DateTime.Now.Date, result.Date);
        }

        [Fact]
        public void Should_DeleteBarbecue_When_HandlerIsActivated()
        {
            _repository.Setup(o => o.Delete(It.IsAny<Guid>())).Returns(Task.FromResult(new Barbecue()));
            _repository.Setup(o => o.Commit()).Callback(() => { });
            var result = _handler.Handle(new CancelBarbecue.CancelBarbecueBuilder(Guid.NewGuid()).Please(), default).Result;
            Mock.VerifyAll();
            Assert.Equal(Unit.Value, result);
        }
    }
}
