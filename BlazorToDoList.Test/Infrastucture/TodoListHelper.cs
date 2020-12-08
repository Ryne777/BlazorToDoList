using BlazorToDoList.Data.Models;
using System;
using System.Collections.Generic;

namespace BlazorToDoList.Test.Infrastucture
{
    public class TodoListHelper : IDisposable
    {
        public static IEnumerable<ToDo> GetMany()
        {
            yield return GetOne();
        }

        public static ToDo GetOne()
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