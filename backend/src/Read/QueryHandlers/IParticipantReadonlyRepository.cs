using System.Collections.Generic;
using System.Threading.Tasks;
using Read.Dtos;

namespace Read.QueryHandlers
{
    public interface IParticipantReadonlyRepository
    {
        Task<IEnumerable<Participant>> GetAll();
    }
}