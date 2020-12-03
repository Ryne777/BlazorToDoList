using BlazorToDoList.Data.Models;
using System;
using System.Collections.Generic;

namespace BlazorToDoList.Test.Infrastucture
{
    public class TodoListHelper : IDisposable
    {
        public  IEnumerable<ToDo> GetMany()
        {
            yield return GetOne();
        }

        public  ToDo GetOne()
        {
            return new ToDo
            {
                Id = Guid.NewGuid(),
                Description = "test description",
                Status = Status.InWork
            };
        }

        public void Dispose()
        {
            
            GC.SuppressFinalize(this);
        }
    }
}