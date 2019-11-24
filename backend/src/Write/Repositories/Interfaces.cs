using System;
using System.Linq;
using System.Threading.Tasks;
using Write.Pocos;

namespace Write.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity entity);
        Task<TEntity> Find(Guid key);
        IQueryable<TEntity> GetAll();
        Task<TEntity> Delete(Guid key);
        TEntity Delete(TEntity entity);
        Task Commit();
    }
    public interface IBarbecueRepository : IRepository<Barbecue>
    {
    }

    public interface IPresenceRepository : IRepository<Presence>
    {

    }
}
