using CrossCutting;
using Write.Pocos;

namespace Write.Repositories
{
    public interface IBarbecueRepository : IRepository<Barbecue>
    {
    }

    public interface IPresenceRepository : IRepository<Presence>
    {

    }
}
