using System.Text;
using RabbitMQ.Client;

const string MainHostName = "localhost";

var factory = new ConnectionFactory { HostName = MainHostName };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

const string MainQueue = "task_queue";

channel.QueueDeclare(
    queue: MainQueue,
    durable: true,
    exclusive: false,
    autoDelete: false,
    arguments: null
);

string[] queueMessages = ["1st msg.", "2st msg..", "3st msg...", "4st msg....", "5st msg....."];

foreach (var message in queueMessages)
{
    var body = Encoding.UTF8.GetBytes(message);

    var properties = channel.CreateBasicProperties();
    properties.Persistent = true;

    channel.BasicPublish(
        exchange: string.Empty,
        routingKey: MainQueue,
        basicProperties: null,
        body: body
    );

    Console.WriteLine($" [x] Sent {message}");
}

Console.WriteLine($"Press a key to exit.");
Console.ReadLine();