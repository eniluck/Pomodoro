using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomodoro.Api.Contracts.Requests.Task;
using Pomodoro.BL;
using Pomodoro.Core;
using Pomodoro.DAL.Postgres;
using Xunit;

namespace Pomodoro.IntegrationTests
{
    public class TasksControllerTests
    {
        private readonly HttpClient _client;

        public TasksControllerTests()
        {
            var app = new WebApplicationFactory<Program>();
            app.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    /*
                    //servicies.AddScoped
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<PomodoroDbContext>));

                    services.Remove(descriptor);

                    services.AddDbContext<PomodoroDbContext>(options =>
                        options.UseNpgsql(
                            connectionString,
                            x => x.MigrationsAssembly("Pomodoro.DAL.Postgres")));*/
                });
            })
                ;

            _client = app.CreateClient();
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
            //how can i prepare for this scenario?

            var id = 1;

            var putTaskRequest = new PutTaskRequest()
            {
                Name = "some",
                CategoryId = 1,
                PomodoroEstimation = 1,
                Status = Core.Models.TaskStatusModel.InList,
            };

            var response = await _client.PutAsJsonAsync($"api/tasks/{id}", putTaskRequest);

            response.EnsureSuccessStatusCode();
        }
    }


}