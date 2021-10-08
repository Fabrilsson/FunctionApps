using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Net.Http;

namespace BotPing.Function
{
    public class BotPingFunction
    {
        private readonly HttpClient _client;

        public BotPingFunction(HttpClient client)
        {
            _client = client;
        }

        [FunctionName("BotPingFunction")]
        public async Task Run([TimerTrigger("*/5 * * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "");

            await _client.SendAsync(requestMessage);
        }
    }
}
