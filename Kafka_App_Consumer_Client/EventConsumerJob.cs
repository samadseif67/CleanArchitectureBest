using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafka_App_Consumer_Client
{
    public class EventConsumerJob : BackgroundService
    {
        private readonly ILogger<EventConsumerJob> _logger;
        public EventConsumerJob(ILogger<EventConsumerJob> logger)
        {
            _logger=logger;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "test-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe("test-topic");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                   var consumResult=consumer.Consume(TimeSpan.FromSeconds(5));
                    if(consumResult==null)
                    {
                        continue;
                    }


                    _logger.LogInformation($"consume of the message : {consumResult.Value}  at :{consumResult.Offset}");


                }
                catch (OperationCanceledException)
                {

                    throw;
                }
            }




            return Task.CompletedTask;
        }
    }
}
