using Write.Pocos;

namespace Write.Repositories
{
    internal class PresenceRepository : Repository<Presence>, IPresenceRepository
    {
        public PresenceRepository(WriteContext context) : base(context)
        {
        }
    }
}
