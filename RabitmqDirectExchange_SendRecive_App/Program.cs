
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System.Text;



await Sender();//Send Msg for rabitMq
await Recive();//Recive Msg For rabitMq


async Task<bool> Sender()
{
    var factory = new ConnectionFactory();

    //username guest
    //password guest
    factory.Uri = new Uri("amqp://guest:guest@localhost:5672");

    using var connection = await factory.CreateConnectionAsync();
    using var channel = await connection.CreateChannelAsync();


    //exclusive در صورتی true باشد بمحض قطع شدن ارتباط صف حذف میشود
    string QueueName = "helloQueue";//نام صف
    if (!await QueueExists(QueueName))
        await channel.QueueDeclareAsync(queue: QueueName, durable: true, exclusive: false, autoDelete: false,
        arguments: null);

    string randomNumber = Guid.NewGuid().ToString();
    string message = ("Hello World 14041404!" + randomNumber);
    var body = Encoding.UTF8.GetBytes(message);


    //routingKey   نام صف باید قرار گیرد
    //exchange وقتی خالی باشد یعنی directExchange
    await channel.BasicPublishAsync(exchange: string.Empty, routingKey: QueueName, body: body);//ارسال پیام به صف مورد نظر 
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

    string QueueName = "helloQueue";//نام صف

    if (!await QueueExists(QueueName))
        await channel.QueueDeclareAsync(queue: QueueName, durable: true, exclusive: false, autoDelete: false,
            arguments: null);



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