using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Read.Dtos;

namespace Read
{
    public interface IBarbecueReadonlyRepository
    {
        Task<IEnumerable<BarbecueDto>> GetAll();
        Task<BarbecueInfo> GetBy(Guid id);
    }
}