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
            var factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(x =>
                {
                    x.UseEnvironment("Tests");
                });

            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetTaskTest()
        {
            var response = await Client.GetAsync("api/tasks");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CreateTask_shouldReturnOk()
        {
            var newTask = new CreateTaskRequest()
            {
                Name = "string",
                CategoryId = null,
            };

            var response = await Client.PostAsJsonAsync("api/tasks", newTask);

            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("     ")]
        [InlineData(null)]
        public async Task CreateTask_shouldReturnBadRequest(string name)
        {
            var newTask = new CreateTaskRequest()
            {
                Name = name,
                CategoryId = null,
            };

            var response = await Client.PostAsJsonAsync("api/tasks", newTask);

            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateTask_shouldReturnOK()
        {
            var id = 1;

            var putTaskRequest = new UpdateTaskRequest()
            {
                Name = "some",
                CategoryId = null,
                PomodoroEstimation = 1,
                Status = Core.Models.TaskStatusModel.InList,
            };

            var response = await Client.PutAsJsonAsync($"api/tasks/{id}", putTaskRequest);

            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("     ")]
        [InlineData(null)]
        public async Task UpdateTask_shouldReturnBadRequest(string name)
        {
            var id = 1;

            var putTaskRequest = new UpdateTaskRequest()
            {
                Name = name,
                CategoryId = null,
                PomodoroEstimation = 1,
                Status = Core.Models.TaskStatusModel.InList,
            };

            var response = await Client.PutAsJsonAsync($"api/tasks/{id}", putTaskRequest);

            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task DeleteTask_ShouldReturnOK()
        {
            var fixture = new Fixture();
            var id = await MakeTask(fixture);

            var response = await Client.DeleteAsync($"api/tasks/{id}");

            response.EnsureSuccessStatusCode();
            var resultBody = await response.Content.ReadAsStringAsync();
            Assert.Equal("true", resultBody);
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

        [Fact]
        public async Task DeleteTask_ShouldReturnFalse()
        {
            int id = 3;
            var response = await Client.DeleteAsync($"api/tasks/{id}");
            var resultBody = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            Assert.Equal("false", resultBody);
        }
    }
}