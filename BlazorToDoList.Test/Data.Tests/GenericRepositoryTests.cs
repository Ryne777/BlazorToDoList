using BlazorToDoList.Data;
using BlazorToDoList.Data.Models;
using BlazorToDoList.Data.Repository;
using BlazorToDoList.Test.Infrastucture;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlazorToDoList.Test.Data.Tests
{
    public class GenericRepositoryTests
    {
        [Fact]
        public void Try_Use_Generic_repository()
        {
            // Arrange            
            var expected = "test description";
            var context = new DbContextHelper();
            // Act
            var rep = new EFGenericRepository<ToDo>(context.Context);
            var actual = rep.GetAll().Result.FirstOrDefault<ToDo>();
            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Description);
        }
        // TODO: finish Tests
    }
}
