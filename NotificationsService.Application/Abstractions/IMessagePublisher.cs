using NotificationsService.Contracts;

namespace NotificationsService.Application.Abstractions;

public interface IMessagePublisher
{
    public Task PublishAsync(NotificationCreated notificationCreated);
}