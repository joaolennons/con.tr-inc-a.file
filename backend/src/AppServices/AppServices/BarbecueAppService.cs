using Api.ViewModels;
using Domain;
using MediatR;
using System;
using System.Threading.Tasks;

namespace AppServices
{
    internal class BarbecueAppService : IBarbecueAppService
    {
        private readonly IMediator _dispatcher;
        public BarbecueAppService(IMediator dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public async Task<Guid> CreateBarbecue(Barbecue bbq)
        {
            return await _dispatcher.Send(
                    EventOrganizer
                        .ScheduleNewBarbecue
                        .Named(bbq.Description)
                        .At(bbq.Date)
                        .WithObservation(bbq.Observation)
                        .Please());
        }

        public async Task<DateTime> UpdateBarbecue(Barbecue bbq)
        {
            return await _dispatcher.Send(
                    EventOrganizer
                        .UpdateBarbecue(bbq.Id)
                        .Named(bbq.Description)
                        .At(bbq.Date)
                        .WithObservation(bbq.Observation)
                        .Please());
        }

        public async Task DeleteBarbecue(Guid id)
        {
            await _dispatcher.Send(
                    EventOrganizer
                    .CancelBarbecue(id)
                    .Please());
        }
    }
}
