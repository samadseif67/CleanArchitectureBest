//در این قسمت به این صورت است که پیام از طریق یک اکسچنج ارسال میشود 
//در صمت گیرندگان این اکسچنج به صف های وصل میشود سپس از طریق این صف ها میتوان پیام ها را خواند
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System.Text;





for (int i = 0; i < 3; i++)
{
    await Sender();//Send Msg for rabitMq
}

await Recive();//Recive Msg For rabitMq


async Task<bool> Sender()
{
    var factory = new ConnectionFactory();

    //username guest
    //password guest
    factory.Uri = new Uri("amqp://guest:guest@localhost:5672");

    using var connection = await factory.CreateConnectionAsync();
    using var channel = await connection.CreateChannelAsync();


    string ExchangeName = "Order.Header";
    await channel.ExchangeDeclareAsync(exchange: ExchangeName, type: ExchangeType.Headers, durable: true);



    var properties = new BasicProperties();
    properties.Headers = new Dictionary<string, object>();
    properties.Headers.Add("location", "us");
    properties.Headers.Add("temperature", "38");






    string randomNumber = Guid.NewGuid().ToString();
    string message = ("Hello World 14041404!" + randomNumber);
    var body = Encoding.UTF8.GetBytes(message);


    //routingKey   نام صف باید قرار گیرد
    //exchange وقتی خالی باشد یعنی directExchange
    await channel.BasicPublishAsync(exchange: ExchangeName, routingKey: "", body: body, basicProperties: properties, mandatory: true);//ارسال پیام به صف مورد نظر 

    Console.WriteLine($" [x] Sent {message}");

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
    return true;
}

async Task<bool> Recive()
{
    var factory = new ConnectionFactory();

    //username guest
    //password guest
    factory.Uri = new Uri("amqp://guest:guest@localhost:5672");

    using var connection = await factory.CreateConnectionAsync();
    using var channel = await connection.CreateChannelAsync();



    string QueueName = "QueueHeader";//نام صف
    string ExchangeName = "Order.Header";

    if (!await QueueExists(QueueName))
    {
        await channel.QueueDeclareAsync(queue: QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
    }


    var bindingHeaders = new Dictionary<string, object>()
    {
   // {"x-match", "any"},//در صورتی که انی باشد یعنی یکی از هدرها ارسال کننده و دریافت کننده برابر باشد پیام را دریافت کند
    {"x-match", "all"},//در صورتی که آل باشد یعنی تمام   هدرها ارسال کننده و دریافت کننده باید برابر باشد پیام را دریافت کند
    {"location", "us"}
    };


    await channel.QueueBindAsync(queue: QueueName, exchange: ExchangeName, routingKey: "", bindingHeaders);


     


    var consumer = new AsyncEventingBasicConsumer(channel);
    consumer.ReceivedAsync += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine($" [x] Received {message}");
        channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, false);
        return Task.CompletedTask;
    };

    await channel.BasicConsumeAsync(QueueName, autoAck: false, consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
    return true;
}


async Task<bool> QueueExists(string queueName)
{
    try
    {
        var factory = new ConnectionFactory();
        //username guest
        //password guest
        factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();
        await channel.QueueDeclarePassiveAsync(queueName);
        return true;

    }
    catch (OperationInterruptedException ex)
    {
        if (ex.ShutdownReason.ReplyCode == 404)
        {
            return false;
        }
        throw;
    }

}