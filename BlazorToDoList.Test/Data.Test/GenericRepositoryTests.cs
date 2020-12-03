using BlazorToDoList.Data;
using BlazorToDoList.Data.Models;
using BlazorToDoList.Data.Repository;
using BlazorToDoList.Test.Infrastucture;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlazorToDoList.Test.Data.Test
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
            var actual = rep.Get(Guid.Parse("e5291737-bf7a-4f8f-8936-11999db20dac")).Result;
            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Description);
        }
        // TODO: finish Tests
    }
}
