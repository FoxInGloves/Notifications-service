using NotificationsService.Application.Abstractions;
using NotificationsService.Contracts;

namespace NotificationsService.Infrastructure.Messaging;

public class RabbitMqMessagePublisher : IMessagePublisher
{
    public Task PublishAsync(NotificationCreated notificationCreated)
    {
        throw new NotImplementedException();
    }
}