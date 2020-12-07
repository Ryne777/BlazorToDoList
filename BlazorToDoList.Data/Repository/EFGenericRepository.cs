using BlazorToDoList.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace BlazorToDoList.Data.Repository
{
    public class EFGenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _db;


        public EFGenericRepository(DbContext dbContext)
        {
            _db = dbContext;

        }
        public async Task Create(TEntity item)
        {
            await _db.AddAsync<TEntity>(item);
            
        }

        public async Task Delete(Guid id)
        {
            _db.Remove<TEntity>(await Get(id));

        }

        public async Task<IEnumerable<TEntity>> Find(Func<TEntity, bool> predicate)
        {
            return await _db.Set<TEntity>().AsNoTracking().Where(predicate).AsQueryable().ToListAsync();
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await _db.FindAsync<TEntity>(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll() => await _db.Set<TEntity>().ToListAsync();


        public void Update(TEntity item)
        {            
            _db.Update(item);           
            
        }
        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _db.Set<TEntity>().AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
