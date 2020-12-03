using BlazorToDoList.Data.Models;
using BlazorToDoList.Data.Repository;
using BlazorToDoList.Test.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BlazorToDoList.Test.Data.Test
{
    public class GenericUnitOfWorkTests
    {
        [Fact]
        public void Try_Use_Generic_UnitOFWork()
        {
            // Arrange            
            var expected = "test description";
            var context = new DbContextHelper();

            // Act
            var rep = new EFGenericUnitOfWork<EFGenericRepository<ToDo>, ToDo>(context.Context);
            var res = rep.Repository();
            var actual = res.GetAll().Result.FirstOrDefault<ToDo>();
            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Description);
        }
        // TODO: finish Tests
    }
}
