using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorToDoList.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> Find(Func<T, Boolean> predicate);
        Task Create(T item);
        void Update(T item);
        Task Delete(Guid id);
    }
}
