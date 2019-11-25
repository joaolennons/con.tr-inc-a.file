using Api.ViewModels;
using Domain;
using MediatR;
using System;
using System.Threading.Tasks;

namespace AppServices
{
    internal class ParticipantAppService : IParticipantAppService
    {
        private readonly IMediator _dispatcher;
        public ParticipantAppService(IMediator dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public async Task ConfirmPresence(Guid id, Presence presence)
        {
            await _dispatcher.Send(
                EventOrganizer
                    .ConfirmPresence
                    .Of(presence.ParticipantId)
                    .On(id)
                    .PayingBy(presence.Drinking ? Drinking.Yes : Drinking.No)
                    .Please());
        }

        public async Task UpdatePresence(Guid id, Presence presence)
        {
            await _dispatcher.Send(
                    EventOrganizer
                        .UpdatePresence
                        .Of(presence.ParticipantId)
                        .On(id)
                        .PayingBy(presence.Drinking ? Drinking.Yes : Drinking.No)
                        .IsPaid(presence.Paid)
                        .Please());
        }

        public async Task UpdatePayment(Guid id, Guid participantId, Payment payment)
        {
            await _dispatcher.Send(
                   EventOrganizer
                       .UpdatePayment
                       .Of(participantId)
                       .On(id)
                       .SetPaid(payment.Paid)
                       .Please());
        }

        public async Task CancelPresence(Guid id, Guid participantId, bool wasPaid)
        {
            await _dispatcher.Send(
                    EventOrganizer
                        .CancelPresence
                        .Of(participantId)
                        .On(id)
                        .WasPaid(wasPaid)
                        .Please());
        }
    }
}
