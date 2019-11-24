using System;
using System.Threading.Tasks;

namespace CrossCutting
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity entity);
        Task<TEntity> Find(Guid key);
        Task<TEntity> Delete(Guid key);
        Task Commit();
    }
}
