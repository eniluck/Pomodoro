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
            // arrange
            var fixture = new Fixture();

            // act
            var (newTask, errors) = TaskModel.Create(fixture.Create<string>(), null, TaskStatusModel.InList, fixture.Create<int>());

            // assert
            Assert.NotNull(newTask);
            Assert.Empty(errors);
        }

        [Fact]
        public void Create_ShouldReturnTheSameModel()
        {
            // arrange
            var fixture = new Fixture();
            var name1 = fixture.Create<string>();
            var int1 = fixture.Create<int>();
            var intEstimation1 = fixture.Create<int>();


            // act
            var (newTask1, _) = TaskModel.Create(name1, null, TaskStatusModel.InList, intEstimation1);
            var (newTask2, _) = TaskModel.Create(name1, null, TaskStatusModel.InList, intEstimation1);

            // assert
            Assert.True(newTask1 == newTask2);
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
            var intEstimation1 = fixture.Create<int>();
            var intEstimation2 = fixture.Create<int>();

            // act
            var (newTask1, _) = TaskModel.Create(name1, null, TaskStatusModel.InList, intEstimation1);
            var (newTask2, _) = TaskModel.Create(name2, null, TaskStatusModel.InList, intEstimation2);

            // assert
            Assert.False(newTask1 == newTask2);
        }
    }
}
