using Confluent.Kafka;

namespace Kafka_App.Services
{
    public class ProducerService
    {
        private readonly ILogger<ProducerService> _logger;
        public ProducerService(ILogger<ProducerService> logger)
        {
            _logger = logger;
        }


        public async Task ProducerAsync(CancellationToken cancellationToken)
        {
            var config = new ProducerConfig
            {
                BootstrapServers="localhost:9092",
                AllowAutoCreateTopics=true,
                Acks=Acks.All
            };

           using var producer=new ProducerBuilder<Null,string>(config).Build();

            try
            {
                var deliveryResult = await producer.ProduceAsync(topic: "test-topic",
                    new Message<Null, string>() { Value = $"Hello kafaka{DateTime.Now}" },
                    cancellationToken);
                _logger.LogInformation($"Delivery messaging {deliveryResult.Value} , offset:{deliveryResult.Offset}");
            }
            catch (ProduceException<Null,string> ex)
            {
                _logger.LogInformation($"Delivery faild {ex.Error.Reason}");       
            }
            producer.Flush(cancellationToken);
        }



    }
}
