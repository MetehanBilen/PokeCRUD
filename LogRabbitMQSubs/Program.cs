using Serilog.Formatting.Compact;
using Serilog;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(new CompactJsonFormatter())
            .CreateLogger();
var factory = new ConnectionFactory()
{
    HostName = "localhost", // RabbitMQ host
    UserName = "guest",     // RabbitMQ username
    Password = "guest"      // RabbitMQ password
};

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare(exchange: "log-Exchange-0807", type: ExchangeType.Direct);
    var queueName = channel.QueueDeclare().QueueName;
    channel.QueueBind(queue: queueName, exchange: "log-Exchange-0807", routingKey: "PokeLog");

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);

        Console.WriteLine(message);
    };

    channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

    Console.WriteLine("Listening for logs. Press any key to exit.");
    Console.ReadKey();

}
    
