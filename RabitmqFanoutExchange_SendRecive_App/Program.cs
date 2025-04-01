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


    string ExchangeName = "food.exchange";
    await channel.ExchangeDeclareAsync(exchange:ExchangeName,type:ExchangeType.Fanout,durable:true);

    //*************************************************************

    List<string> LstQueueName = new List<string>() {"Queuefoo"};//نام صف های که قرار هست به این اکسچنج وصل شوند
    foreach (var item in LstQueueName)
    {
        string QueueName = item;
        if (!await QueueExists(QueueName))
        {
            await channel.QueueDeclareAsync(queue: QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
        }
        await channel.QueueBindAsync(queue: QueueName, exchange: ExchangeName, routingKey: "", null);//وصل کردن صف به اکسچنج
    } 

    //**************************************************************



    string randomNumber = Guid.NewGuid().ToString();
    string message = ("Hello World 14041404!" + randomNumber);
    var body = Encoding.UTF8.GetBytes(message);


    //routingKey   نام صف باید قرار گیرد
    //exchange وقتی خالی باشد یعنی directExchange
    await channel.BasicPublishAsync(exchange: ExchangeName, routingKey: "",body: body);//ارسال پیام به صف مورد نظر 
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



    string QueueName = "Queuefoo";//نام صف
    string ExchangeName = "food.exchange";
   
    if (!await QueueExists(QueueName))
    {
        await channel.QueueDeclareAsync(queue: QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
    }
    await channel.QueueBindAsync(queue: QueueName, exchange: ExchangeName, routingKey: "", null);






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