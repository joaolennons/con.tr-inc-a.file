using System;
using System.Threading.Tasks;
using Api.ViewModels;

namespace AppServices
{
    public interface IParticipantAppService
    {
        Task CancelPresence(Guid id, Guid participantId, bool wasPaid);
        Task ConfirmPresence(Guid id, Presence presence);
        Task UpdatePayment(Guid id, Guid participantId, Payment payment);
        Task UpdatePresence(Guid id, Presence presence);
    }
}