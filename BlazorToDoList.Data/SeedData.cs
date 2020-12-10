using BlazorToDoList.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace BlazorToDoList.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder арр)
        {
            var scopedFactory = арр.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            // create a scope
            using var scope = scopedFactory.CreateScope();
            // then resolve the services and execute it
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (!context.Todos.Any())
            {
                context.Todos.AddRange(
                    new ToDo
                    {
                        Description = "First",
                        Id = Guid.NewGuid(),
                        Status = Status.InWork
                    },
                    new ToDo
                    {
                        Description = "Second",
                        Id = Guid.NewGuid(),
                        Status = Status.InWork
                    });
            }
            context.SaveChanges();
            //ApplicationDbContext context = арр.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            //context.Database.Migrate();


        }
    }
}
