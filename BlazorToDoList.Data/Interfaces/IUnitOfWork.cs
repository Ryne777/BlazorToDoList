using BlazorToDoList.Data.Models;
using System;

namespace BlazorToDoList.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ToDo> Todo { get; }
        
        void Save();
    }
}
