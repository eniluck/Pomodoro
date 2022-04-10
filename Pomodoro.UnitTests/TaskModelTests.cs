using AutoFixture;
using Pomodoro.Core.Models;
using Xunit;

namespace Pomodoro.UnitTests
{
    public class TaskModelTests
    {
        [Fact]
        public void Create_ShouldReturnTaskModel()
        {
            //arrange 
            var fixture = new Fixture();

            //act
            var (newTask, errors) = TaskModel.Create(fixture.Create<string>());

            //assert
            Assert.NotNull(newTask);
            Assert.Empty(errors);
        }

        [Fact]
        public void Create_ShouldReturnTheSameModel()
        {
            //arrange 
            var fixture = new Fixture();
            var name = fixture.Create<string>();

            //act
            var (newTask1, _) = TaskModel.Create(name);
            var (newTask2, _) = TaskModel.Create(name);

            //assert
            Assert.True(newTask1 == newTask2);
        }

        [Fact]
        public void Create_ShouldReturnNotTheSameModel()
        {
            //arrange 
            var fixture = new Fixture();
            var name1 = fixture.Create<string>();
            var name2 = fixture.Create<string>();

            //act
            var (newTask1, _) = TaskModel.Create(name1);
            var (newTask2, _) = TaskModel.Create(name2);

            //assert
            Assert.False(newTask1 == newTask2);
        }
    }
}
