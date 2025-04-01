//در این قسمت به این صورت است که پیام از طریق یک اکسچنج ارسال میشود 
//در سمت گیرندگان این اکسچنج به صف های وصل میشود سپس از طریق این صف ها میتوان پیام ها را خواند
 //به این صورت می باشد که ما پیام ها را از طریق یک مسیر خاصی ارسال میکنیم و سمت گیرنده میتواند از همان مسیر دریافت کند 
 //یا با استفاده از علامت ستاره تمام پیام ها را دریافت کند
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


    string ExchangeName = "Order.Topic";
    string RoutingKey = "Order.Create";
    await channel.ExchangeDeclareAsync(exchange: ExchangeName, type: ExchangeType.Topic, durable: true);

    //*************************************************************

    //List<string> LstQueueName = new List<string>() { "QueueTopic" };//نام صف های که قرار هست به این اکسچنج وصل شوند
    //foreach (var item in LstQueueName)
    //{
    //    string QueueName = item;
    //    if (!await QueueExists(QueueName))
    //    {
    //        await channel.QueueDeclareAsync(queue: QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
    //    }
    //    await channel.QueueBindAsync(queue: QueueName, exchange: ExchangeName, routingKey:"", null);//وصل کردن صف به اکسچنج
    //    //در این قسمت به تمام مسیر های زیر ارسال میشود
    //    //Order.Create
    //}

    //**************************************************************



    string randomNumber = Guid.NewGuid().ToString();
    string message = ("Hello World 14041404!" + randomNumber);
    var body = Encoding.UTF8.GetBytes(message);


    //routingKey   نام مسیری که قرار هست پیام را دریافت کند   
    //exchange وقتی خالی باشد یعنی directExchange
    await channel.BasicPublishAsync(exchange: ExchangeName, routingKey: RoutingKey, body: body);//ارسال پیام به صف مورد نظر 
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



    string QueueName = "OrderService";//نام صف
    string ExchangeName = "Order.Topic";
    //string RoutingKey = "Order.Create";
      string RoutingKey = "Order.*";
    if (!await QueueExists(QueueName))
    {
        await channel.QueueDeclareAsync(queue: QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
    }
    await channel.QueueBindAsync(queue: QueueName, exchange: ExchangeName, routingKey: RoutingKey, null);
    //تمام پیامهای که به مسیر زیر ارسال شده است را بخوان
    //Order.Create
    //در صورتی که بصورت پایان مسیر را تعریف کنیم تمام پیام های ارسالی که شامل الگوی پایین باشند سمت گیرنده میتواند دریافت کند
    //Order.*






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