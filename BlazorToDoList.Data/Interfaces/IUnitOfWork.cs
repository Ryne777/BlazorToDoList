using BlazorToDoList.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorToDoList.Data.Interfaces
{
    public interface IUnitOfWork<TRepo, TEntity> : IDisposable 
        where TRepo : IRepository<TEntity>
        where TEntity : class
    {
        public Dictionary<Type, TRepo> Repositories { get; }

        public TRepo Repository();
        Task Save();
    }
}
