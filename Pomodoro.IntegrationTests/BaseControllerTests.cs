using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;

namespace Pomodoro.IntegrationTests
{
    public abstract class BaseControllerTests
    {
        public BaseControllerTests(ITestOutputHelper outputHelper)
        {
            var factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    var configurationBuilder = new ConfigurationBuilder();
                    configurationBuilder.AddUserSecrets<LoggingHandler>();
                    builder.UseConfiguration(configurationBuilder.Build());

                    // TODO: ДОбавить AppSettings
                    //builder.ConfigureAppConfiguration(b => b.AddConfiguration(configurationBuilder.Build()));
                    //builder.UseConfiguration();
                });

            Client = factory.CreateDefaultClient(new LoggingHandler(outputHelper));
        }

        protected HttpClient Client { get; }
    }
}
