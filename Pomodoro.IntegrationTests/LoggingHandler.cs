using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xunit.Abstractions;

namespace Pomodoro.IntegrationTests
{
    public class LoggingHandler : DelegatingHandler
    {
        private readonly ITestOutputHelper _outputHelper;

        public LoggingHandler(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _outputHelper.WriteLine(request.RequestUri?.ToString());
            await PrintJsonContent(request.Content);

            var response = await base.SendAsync(request, cancellationToken);

            await PrintJsonContent(response.Content);

            return response;
        }

        private async Task PrintJsonContent(HttpContent? content)
        {
            if (content is not null)
            {
                var requestJson = await content.ReadAsStringAsync();

                try
                {
                    var jToken = JToken.Parse(requestJson);
                    _outputHelper.WriteLine(jToken.ToString());
                }
                catch
                {
                    _outputHelper.WriteLine(requestJson);
                }
            }
        }

        // TODO: через потоки
        protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.Send(request, cancellationToken);
        }
    }
}
