using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Pomodoro.DAL.Postgres;
using Pomodoro.DAL.Postgres.Entities;

namespace Pomodoro.IntegrationTests
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            var factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(x =>
                {
                    x.UseEnvironment("Tests");
                });

            var scopeFactory = factory.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<PomodoroDbContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.AddRange(
                        new TaskEntity
                        {
                            Name = "some",
                            PomodoroEstimation = 1,
                            Status = Core.Models.TaskStatusModel.InList,
                            Category = null,
                        },
                        new TaskEntity
                        {
                            Name = "some2",
                            PomodoroEstimation = 1,
                            Status = Core.Models.TaskStatusModel.InList,
                            Category = null,
                        });
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
        }
    }
}
