using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory
{
    HostName = "localhost",
    Port = 5672,
    UserName = "user",
    Password = "password"
};
await using var connection = await factory.CreateConnectionAsync();
await using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(queue: "Email", durable: true, exclusive: false, autoDelete: false,
    arguments: null);

try
{
    Console.WriteLine(" [*] Waiting for messages.");

    var consumer = new AsyncEventingBasicConsumer(channel);
    consumer.ReceivedAsync += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine($" [x] Received {message}");
        return Task.CompletedTask;
    };

    await channel.BasicConsumeAsync("Email", autoAck: true, consumer: consumer);

    await Task.Delay(Timeout.Infinite);
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}
finally
{
    await channel.CloseAsync();
    await connection.CloseAsync();   
}
