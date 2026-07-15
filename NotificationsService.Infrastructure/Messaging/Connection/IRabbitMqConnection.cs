using RabbitMQ.Client;

namespace NotificationsService.Infrastructure.Messaging;

public interface IRabbitMqConnection
{
    Task<IConnection> GetConnectionAsync();
}