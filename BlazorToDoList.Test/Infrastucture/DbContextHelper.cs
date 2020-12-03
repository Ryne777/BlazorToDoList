﻿using BlazorToDoList.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorToDoList.Test.Infrastucture
{
    public class DbContextHelper //:IDisposable
    {
        public ApplicationDbContext Context { get; set; }

        public DbContextHelper()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase("TEST_DB_BLAZOR_TODO_LIST");
            var options = builder.Options;
            Context = new ApplicationDbContext(options);
            var enumerator = new TodoListHelper();
            Context.AddRange(enumerator.GetMany());
            enumerator.Dispose();
            Context.SaveChanges();
            
        }

        //public void Dispose() => Context.Dispose();
    }
}