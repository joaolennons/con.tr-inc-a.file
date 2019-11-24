﻿using CrossCutting;
using System;
using System.Threading.Tasks;

namespace Write
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly WriteContext _context;
        public Repository(WriteContext context)
        {
            _context = context;
        }
        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public async Task<TEntity> Find(Guid key)
            => await _context.Set<TEntity>().FindAsync(key);

        public async Task Commit() => await _context.SaveChangesAsync();

        public async Task<TEntity> Delete(Guid key)
        {
            var entity = await Find(key);
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return entity;
        }
    }
}
