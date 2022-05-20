using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.Extensions.DependencyInjection;
using Pomodoro.Api.Contracts.Requests.Task;
using Pomodoro.DAL.Postgres;
using Pomodoro.DAL.Postgres.Entities;
using Xunit;
using Xunit.Abstractions;

namespace Pomodoro.IntegrationTests
{
    public class TasksControllerTests : BaseControllerTests
    {
        public TasksControllerTests(ITestOutputHelper outputHelper)
            : base(outputHelper)
        {
        }

        [Fact]
        public async Task GetTaskTest()
        {
            // arrange
            // act
            var response = await Client.GetAsync("api/tasks");

            // assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CreateTask_shouldReturnOk()
        {
            // arrange
            var newTask = new CreateTaskRequest()
            {
                Name = "string",
                CategoryId = null,
            };

            // act
            var response = await Client.PostAsJsonAsync("api/tasks", newTask);

            // assert
            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("     ")]
        [InlineData(null)]
        public async Task CreateTask_shouldReturnBadRequest(string name)
        {
            // arrange
            var newTask = new CreateTaskRequest()
            {
                Name = name,
                CategoryId = null,
            };

            // act
            var response = await Client.PostAsJsonAsync("api/tasks", newTask);

            // assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateTask_shouldReturnOK()
        {
            // arrange
            var id = 1;

            var putTaskRequest = new UpdateTaskRequest()
            {
                Name = "some",
                CategoryId = null,
                PomodoroEstimation = 1,
                Status = Core.Models.TaskStatusModel.InList,
            };

            // act
            var response = await Client.PutAsJsonAsync($"api/tasks/{id}", putTaskRequest);

            // assert
            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("     ")]
        [InlineData(null)]
        public async Task UpdateTask_shouldReturnBadRequest(string name)
        {
            // arrange
            var id = 1;

            var putTaskRequest = new UpdateTaskRequest()
            {
                Name = name,
                CategoryId = null,
                PomodoroEstimation = 1,
                Status = Core.Models.TaskStatusModel.InList,
            };

            // act
            var response = await Client.PutAsJsonAsync($"api/tasks/{id}", putTaskRequest);

            // assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task DeleteTask_ShouldReturnOK()
        {
            // arrange
            var fixture = new Fixture();
            var id = await MakeTask(fixture);

            // act
            var response = await Client.DeleteAsync($"api/tasks/{id}");

            // assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task DeleteTask_ShouldReturnError()
        {
            // arrange
            int id = 100500;

            // act
            var response = await Client.DeleteAsync($"api/tasks/{id}");

            // assert
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        private async Task<int> MakeTask(Fixture fixture)
        {
            using (var scope = Application.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<PomodoroDbContext>();
                var taskEntity = fixture
                    .Build<TaskEntity>()
                    .Without(x => x.Id)
                    .Without(x => x.CategoryId)
                    .Create();

                var entry = dbContext.Tasks.Add(taskEntity);
                await dbContext.SaveChangesAsync();
                return entry.Entity.Id;
            }
        }
    }
}