using BlazorToDoList.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlazorToDoList.Data.Repository
{
    class EFGenericRepository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext _db;        
        

        public EFGenericRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
           
        }
        public async Task Create(T item)
        {
            await _db.AddAsync<T>(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
             _db.Remove<T>( await Get(id));

        }

        public async Task<IEnumerable<T>>Find(Func<T, bool> predicate)
        {
           return await _db.Set<T>().AsNoTracking().Where(predicate).AsQueryable().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
           return await _db.FindAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetAll() =>  await _db.Set<T>().ToListAsync();
        

        public async Task Update(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
