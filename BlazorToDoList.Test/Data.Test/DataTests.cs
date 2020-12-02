using BlazorToDoList.Data.Models;
using BlazorToDoList.Test.Infrastucture;
using System.Linq;
using Xunit;

namespace BlazorToDoList.Test.Data.Test
{
    public class DataTests
    {
        [Fact]
        public void DB_should_be_created()
        {
            // arrange
            var db = new DbContextHelper().Context;

            // act

            // assert
            Assert.NotNull(db);
            db.Dispose();

        }
        [Fact]
        public void DB_should_be_contain_Todo_1()
        {
            // arrange
            var db = new DbContextHelper().Context;
            var exepected = 1;

            // act
            var actual = db.Todos.Count();
            // assert
            Assert.Equal(exepected, actual);
            db.Dispose();
        }

    }
}
