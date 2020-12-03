using BlazorToDoList.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorToDoList.Data.Repository
{
    public class EFGenericUnitOfWork<TRepo, TEntity> : IUnitOfWork<TRepo, TEntity>
        where TRepo : EFGenericRepository<TEntity>
        where TEntity : class
    {
        private bool _disposing = false;
        private ApplicationDbContext _context;

        public EFGenericUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public Dictionary<Type, TRepo> Repositories => new Dictionary<Type, TRepo>();

        public void Dispose()
        {
            if (!_disposing)
            {
                _disposing = true;
                this._context.Dispose();
            }
        }

        public TRepo Repository()
        {
            if (Repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return Repositories[typeof(TEntity)];
            }
            TRepo repo = (TRepo)Activator.CreateInstance(
                typeof(TRepo),
                _context);
            Repositories.Add(typeof(TEntity), repo);
            return repo;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
