using System.Text;
using NotificationsService.Application.Abstractions;
using NotificationsService.Contracts;
using RabbitMQ.Client;

namespace NotificationsService.Infrastructure.Messaging;

public class RabbitMqMessagePublisher : IMessagePublisher
{
    
    
    public async Task PublishAsync(NotificationCreated notificationCreated)
    {
        var factory = new ConnectionFactory { HostName = "localhost", Port=5672, UserName = "user", Password = "password" };
        await using var connection = await factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(queue: "Email", durable: true, exclusive: false, autoDelete: false,
            arguments: null);

        var message = notificationCreated.Id.ToString();
        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "Email", body: body);
    }
}