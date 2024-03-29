﻿using BlazorToDoList.Bl.Interfaces;
using BlazorToDoList.Bl.ViewModels;
using BlazorToDoList.Data.Models;
using BlazorToDoList.Web.Server.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var mockSer = new Mock<IToDoService>();
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
