using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using System.IO;
using Newtonsoft.Json;



namespace GridTimerTrigger
{
    public class TimeToQueue
    {
        [FunctionName("Function1")]
        public void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", true, true)
                .AddEnvironmentVariables()
                .Build();


            var queueName = configuration["AzureQueueName"];
            QueueClient queueClient = new QueueClient(configuration["AzureWebJobsStorage"], queueName, new
                                        QueueClientOptions()
            { MessageEncoding = QueueMessageEncoding.Base64 });
            queueClient.CreateIfNotExists();

            Article newArticle = new()
            {
                Id = 1,
                Header = "Exposion in factory",
                Body = "Blabla"
            };
            var serializedArticle = JsonConvert.SerializeObject(newArticle);
            queueClient.SendMessage(serializedArticle);
            log.LogInformation("Item sent to queue");
        }
    }
    public class Article
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
    }
}
