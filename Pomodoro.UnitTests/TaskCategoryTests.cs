using AutoFixture;
using Pomodoro.Core.Models;
using Xunit;

namespace Pomodoro.UnitTests
{
    public class TaskCategoryTests
    {
        [Fact]
        public void Create_ShouldReturnTaskCategory()
        {
            // arrange
            var fixture = new Fixture();

            // act
            var (newTaskCategory, errors) = TaskCategory.Create(fixture.Create<string>());

            // assert
            Assert.NotNull(newTaskCategory);
            Assert.Empty(errors);
        }

        [Fact]
        public void Create_ShouldReturnTheSameModel()
        {
            // arrange
            var fixture = new Fixture();
            var name1 = fixture.Create<string>();
            var int1 = fixture.Create<int>();

            // act
            var (newTaskCategory1, _) = TaskCategory.Create(name1);
            var (newTaskCategory2, _) = TaskCategory.Create(name1);

            // assert
            Assert.True(newTaskCategory1 == newTaskCategory2);
        }

        [Fact]
        public void Create_ShouldReturnNotTheSameModel()
        {
            // arrange
            var fixture = new Fixture();
            var name1 = fixture.Create<string>();
            var name2 = fixture.Create<string>();
            var int1 = fixture.Create<int>();
            var int2 = fixture.Create<int>();

            // act
            var (newTaskCategory1, _) = TaskCategory.Create(name1);
            var (newTaskCategory2, _) = TaskCategory.Create(name2);

            // assert
            Assert.False(newTaskCategory1 == newTaskCategory2);
        }
    }
}
