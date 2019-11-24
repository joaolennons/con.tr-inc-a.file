using System;
using System.Linq;
using System.Threading.Tasks;

namespace CrossCutting
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
}
