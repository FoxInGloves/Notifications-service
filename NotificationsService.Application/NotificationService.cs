using NotificationsService.Application.Abstractions;
using NotificationsService.Contracts;
using NotificationsService.Domain;

namespace NotificationsService.Application;

public class NotificationService
{
    private readonly INotificationsRepository _notificationsRepository;
    private readonly IMessagePublisher _messagePublisher;

    public NotificationService(INotificationsRepository notificationsRepository)
    {
        _notificationsRepository = notificationsRepository;
    }
    
    public async Task<Guid> CreateNotificationAsync(CreateNotificationCommand command)
    {
        var notification = Notification.Create(command.Title, command.Message, command.Recipient);
        
        await _notificationsRepository.AddNotificationAsync(notification);

        await _messagePublisher.PublishAsync(new NotificationCreated(notification.Id));
        
        return notification.Id;
    }
}