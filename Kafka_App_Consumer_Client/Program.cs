
using Kafka_App_Consumer_Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

 
 public class Program
{
    public static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddHostedService<EventConsumerJob>();
            })
            .ConfigureLogging(logging =>
            {
                
            })
            .Build();

        await host.RunAsync();
    }
}