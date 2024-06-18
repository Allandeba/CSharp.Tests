using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

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

channel.BasicQos(
    prefetchSize: 0,
    prefetchCount: 1,
    global: false
);

Console.WriteLine($" [*] Waiting for messages from {MainHostName}");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) => {
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received {message}");

    int dots = message.Split('.').Length - 1;
    Thread.Sleep(dots * 1000);
    Console.WriteLine($" [x] Done");

    channel.BasicAck(
        deliveryTag: ea.DeliveryTag,
        multiple: false
    );
};
channel.BasicConsume(
    queue: MainQueue,
    autoAck: false,
    consumer: consumer
);

Console.WriteLine($" Press a key to exit.");
Console.ReadLine();