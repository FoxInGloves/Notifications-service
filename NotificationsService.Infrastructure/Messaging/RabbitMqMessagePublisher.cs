using System.Text;
using NotificationsService.Application.Abstractions;
using NotificationsService.Contracts;
using RabbitMQ.Client;

namespace NotificationsService.Infrastructure.Messaging;

public class RabbitMqMessagePublisher : IMessagePublisher
{
    private readonly IRabbitMqConnection _rabbitMqConnection;
    
    public RabbitMqMessagePublisher(IRabbitMqConnection rabbitMqConnection)
    {
        _rabbitMqConnection = rabbitMqConnection;
    }

    public async Task PublishAsync(NotificationCreated notificationCreated)
    {
        var connection = await _rabbitMqConnection.GetConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();

        var routingKey = notificationCreated.Channel switch
        {
            NotificationChannelEnum.Email => "Email",
            NotificationChannelEnum.Sms => "Sms",
            _ => throw new ArgumentOutOfRangeException()
        };
        
        await channel.QueueDeclareAsync(queue: routingKey, durable: true, exclusive: false, autoDelete: false,
            arguments: null);

        var message = notificationCreated.Id.ToString();
        var body = Encoding.UTF8.GetBytes(message);
        
        await channel.BasicPublishAsync(exchange: string.Empty, routingKey: routingKey, body: body);
    }
}