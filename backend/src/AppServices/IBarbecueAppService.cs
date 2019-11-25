using System;
using System.Threading.Tasks;
using Api.ViewModels;

namespace AppServices
{
    public interface IBarbecueAppService
    {
        Task<Guid> CreateBarbecue(Barbecue bbq);
        Task DeleteBarbecue(Guid id);
        Task<DateTime> UpdateBarbecue(Barbecue bbq);
    }
}