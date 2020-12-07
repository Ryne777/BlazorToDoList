using BlazorToDoList.Bl.Interfaces;
using BlazorToDoList.Bl.ViewModels;
using BlazorToDoList.Data.Interfaces;
using BlazorToDoList.Data.Models;
using BlazorToDoList.Data.Repository;
using BlazorToDoList.Test.Infrastucture;
using BlazorToDoList.Web.Server.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlazorToDoList.Test.Controllers.Tests
{
    public class ControllerTests
    {
        [Fact]
        public void Try_Use_Controller()
        {
            // Arrange         
            var expected = 1;
            var customRep = false;
            var mockUoW = new Mock<IUnitOfWork>();
            var modRep = new Mock<IRepository<ToDo>>();
            var mockSer = new Mock<IToDoService>();
            modRep.Setup(x => x.GetAll()).ReturnsAsync(TodoListHelper.GetMany());
            mockUoW.Setup(x => x.GetRepository<ToDo>(customRep)).Returns(modRep.Object);
            mockSer.Setup(x => x.GetAll()).ReturnsAsync(new List<IndexToDoViewModel>() {
                new IndexToDoViewModel
                {   Description = "1",
                    Id = Guid.NewGuid().ToString(),
                    Status = Status.Completed.ToString() } });
            // Act
            var controller = new ToDoController(mockSer.Object);
            var actual = controller.GetToDoList().Result;
            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count());
        }
    }
}
