using BlazorToDoList.Data.Interfaces;
using BlazorToDoList.Data.Models;
using BlazorToDoList.Data.Repository;
using BlazorToDoList.Test.Infrastucture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BlazorToDoList.Test.Data.Tests
{
    public class GenericUnitOfWorkTests
    {
        [Fact]
        public void Try_Use_Generic_UnitOFWork()
        {
            // Arrange            
            var expected = "test description";
            var customRep = false;
            var context = new DbContextHelper();
            var mockUoW = new Mock<IUnitOfWork>();
            var modRep = new Mock<IRepository<ToDo>>();
            modRep.Setup(x => x.GetAll()).ReturnsAsync(TodoListHelper.GetMany());
            mockUoW.Setup(x => x.GetRepository<ToDo>(customRep)).Returns(modRep.Object);
            // Act


            var actual = mockUoW.Object.GetRepository<ToDo>().GetAll().Result.FirstOrDefault<ToDo>();
            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Description);
        }
        // TODO: finish Tests
    }
}
