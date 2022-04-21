using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Pomodoro.Api.Contracts.Requests.Task;
using Xunit;

namespace Pomodoro.IntegrationTests
{
    public class TasksControllerTests : IClassFixture<DatabaseFixture>
    {
        private readonly HttpClient _client;

        public TasksControllerTests()
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
            var response = await _client.GetAsync("api/tasks");

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

            var response = await _client.PostAsJsonAsync("api/tasks", newTask);

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

            var response = await _client.PostAsJsonAsync("api/tasks", newTask);

            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateTask_shouldReturnOK()
        {
            var id = 1;

            var putTaskRequest = new PutTaskRequest()
            {
                Name = "some",
                CategoryId = null,
                PomodoroEstimation = 1,
                Status = Core.Models.TaskStatusModel.InList,
            };

            var response = await _client.PutAsJsonAsync($"api/tasks/{id}", putTaskRequest);

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

            var putTaskRequest = new PutTaskRequest()
            {
                Name = name,
                CategoryId = null,
                PomodoroEstimation = 1,
                Status = Core.Models.TaskStatusModel.InList,
            };

            var response = await _client.PutAsJsonAsync($"api/tasks/{id}", putTaskRequest);

            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task DeleteTask_ShouldReturnOK()
        {
            int id = 2;
            var response = await _client.DeleteAsync($"api/tasks/{id}");

            response.EnsureSuccessStatusCode();
            var resultBody = await response.Content.ReadAsStringAsync();
            Assert.Equal("true", resultBody);
        }

        [Fact]
        public async Task DeleteTask_ShouldReturnFalse()
        {
            int id = 3;
            var response = await _client.DeleteAsync($"api/tasks/{id}");
            var resultBody = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            Assert.Equal("false", resultBody);
        }
    }
}