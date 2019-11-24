using Write.Pocos;
using Write.Repositories;

namespace Write
{
    internal class BarbecueRepository : Repository<Barbecue>, IBarbecueRepository
    {
        public BarbecueRepository(WriteContext context) : base(context)
        {
        }
    }
}
