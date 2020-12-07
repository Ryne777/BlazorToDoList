using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazorToDoList.Bl.Interfaces;
using BlazorToDoList.Bl.Services;
using BlazorToDoList.Bl.ViewModels;
using BlazorToDoList.Data.Interfaces;
using BlazorToDoList.Data.Models;
using BlazorToDoList.Test.Infrastucture;
using Moq;
using Xunit;

namespace BlazorToDoList.Test.Bl.Tests
{
    public class ToDoServiceTests
    {
        [Fact]
        public void Try_Use_Service()
        {
            // Arrange
            var expected = 1;    
            var customRep = false;             
            var mockUoW = new Mock<IUnitOfWork>();
            var modRep = new Mock<IRepository<ToDo>>();
            modRep.Setup(x => x.GetAll()).ReturnsAsync(TodoListHelper.GetMany());
            mockUoW.Setup(x => x.GetRepository<ToDo>(customRep)).Returns(modRep.Object);
            // Act
            var service = new ToDoService(mockUoW.Object);
            var actual = service.GetAll().Result;
            // Assert
            Assert.Equal(expected, actual.Count());
        }
        //[Fact]
        //public void Create_ToDo_Use_Service()
        //{
        //    // Arrange
        //    var fakeTodo = new CreateTodoViewModel()
        //    {
        //        Description = "Test description",
        //        Status = "InWork"
        //    };
        //var expected = "Test description";
        //var customRep = false;
        //var mockUoW = new Mock<IUnitOfWork>();
        //var modRep = new Mock<IRepository<ToDo>>();
        //modRep.Setup(x => x.GetAll()).ReturnsAsync(TodoListHelper.GetMany());
        //mockUoW.Setup(x => x.GetRepository<ToDo>(customRep)).Returns(modRep.Object);
        //mockUoW.Setup(x => x.GetRepository<ToDo>(customRep).Create(It.IsAny<ToDo>()));
        //    // Act
        //    var service = new ToDoService(mockUoW.Object);
        //var act = service.CreateToDo(fakeTodo);
        //var actual = service.GetAll().Result;//.Where(x => x.Description == expected).First();
        //                                     // Assert
        //Assert.Equal(expected, actual.First().Description);
        //}



}
}
