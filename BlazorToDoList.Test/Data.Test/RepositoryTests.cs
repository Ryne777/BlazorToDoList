using BlazorToDoList.Data.Interfaces;
using BlazorToDoList.Data.Models;
using BlazorToDoList.Test.Infrastucture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BlazorToDoList.Test.Data.Test
{
    public class RepositoryTests
    {
        List<ToDo> toDoList = new List<ToDo>
        {
            new ToDo
                {
                    Id = Guid.Parse("3ce39381-f57a-4358-856b-a21fc681df7a"),
                    Description = "nEw",
                    Status = Status.Faild

                },
                new ToDo
                {
                    Id = Guid.Parse("b4f323d8-adef-4bc2-908a-58546b21b177"),
                    Description = "nEw 2",
                    Status = Status.InWork

                },
                new ToDo
                {
                    Id = Guid.Parse("536c1972-7f30-4e2c-9511-0afbc61a0c07"),
                    Description = "nEw 3",
                    Status = Status.Completed

                }
        };

        [Fact]
        public void Can_Use_Repository()
        {
            // Arrange
            const int expected = 3;
            var mock = new Mock<IRepository<ToDo>>();
            mock.Setup(x => x.GetAll()).ReturnsAsync(toDoList);
            // Act
            var res = mock.Object.GetAll().Result;
            var actual = res.Count();
            // Assert
            Assert.NotNull(res);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_By_id()
        {
            // Arrange
            var  expected = new ToDo
            {
                Id = Guid.Parse("3ce39381-f57a-4358-856b-a21fc681df7a"),
                Description = "nEw",
                Status = Status.Faild

            };
            var mock = new Mock<IRepository<ToDo>>();
            mock.Setup(x => x.Get(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) => toDoList.Single(c => c.Id == id));
            
            // Act
            
            var actual = mock.Object.Get(Guid.Parse("3ce39381-f57a-4358-856b-a21fc681df7a")).Result;
            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected.Id, actual.Id);
        }

        [Fact]
        public void Get_By_Find()
        {
            // Arrange
            var expected = new ToDo
            {
                Id = Guid.Parse("3ce39381-f57a-4358-856b-a21fc681df7a"),
                Description = "nEw",
                Status = Status.Faild

            };
            var mock = new Mock<IRepository<ToDo>>();
            mock.Setup(x => x.Find(It.IsAny<Func<ToDo, bool>>()))
                .ReturnsAsync((Func<ToDo, bool> func) => toDoList.Where(func));

            // Act

            var actual = mock.Object.Find(x => x.Status == Status.Faild).Result.First();
            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected.Id, actual.Id);
        }

        [Fact]
        public void Create_Todo_Call_Repository_Create()
        {
            // Arrange
            var expected = new ToDo
            {
                Id = Guid.Parse("228f89dc-16fe-49bf-8b32-fcf7db3391ab"),
                Description = "nEw",
                Status = Status.Faild

            };
            var mock = new Mock<IRepository<ToDo>>();
            mock.Setup(x => x.Create(It.IsAny<ToDo>()));
                

            // Act

            var actual = mock.Object.Create(expected);
            // Assert
            Assert.NotNull(actual);
            mock.Verify(x => x.Create(expected), Times.Once());
        }

        [Fact]
        public void Delete_Todo_Call_Repository_Create()
        {
            // Arrange
            var expected = new ToDo
            {
                Id = Guid.Parse("228f89dc-16fe-49bf-8b32-fcf7db3391ab"),
                Description = "nEw",
                Status = Status.Faild

            };
            var mock = new Mock<IRepository<ToDo>>();
            mock.Setup(x => x.Delete(It.IsAny<Guid>()));


            // Act

            var actual = mock.Object.Delete(Guid.Parse("228f89dc-16fe-49bf-8b32-fcf7db3391ab"));
            // Assert
            Assert.NotNull(actual);
            mock.Verify(x => x.Delete(Guid.Parse("228f89dc-16fe-49bf-8b32-fcf7db3391ab")), Times.Once());
        }
    }
}
