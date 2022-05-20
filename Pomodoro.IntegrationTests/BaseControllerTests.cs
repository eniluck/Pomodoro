using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomodoro.DAL.Postgres;
using Xunit.Abstractions;

namespace Pomodoro.IntegrationTests
{
    public abstract class BaseControllerTests
    {
        public BaseControllerTests(ITestOutputHelper outputHelper)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddUserSecrets<LoggingHandler>();
            var configuration = configurationBuilder.Build();

            var connectionString = configuration.GetConnectionString(nameof(PomodoroDbContext));

            Application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.UseConfiguration(configuration);

                    // TODO: ДОбавить AppSettings
                    //builder.ConfigureAppConfiguration(b => b.AddConfiguration(configurationBuilder.Build()));
                    //builder.UseConfiguration();
                });

            //var dbContenct = factory.Server.Services.GetRequiredService<IConfiguration>()
            Client = Application.CreateDefaultClient(new LoggingHandler(outputHelper));
        }

        protected WebApplicationFactory<Program> Application { get; }

        protected HttpClient Client { get; }
    }
}
