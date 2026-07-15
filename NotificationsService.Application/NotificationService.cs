using NotificationsService.Application.Abstractions;
using NotificationsService.Contracts;
using NotificationsService.Domain;

namespace NotificationsService.Application;

public class NotificationService
{
    private readonly INotificationsRepository _notificationsRepository;
    private readonly IMessagePublisher _messagePublisher;

    public NotificationService(INotificationsRepository notificationsRepository, IMessagePublisher messagePublisher)
    {
        _notificationsRepository = notificationsRepository;
        _messagePublisher = messagePublisher;
    }
    
    public async Task<Guid> CreateNotificationAsync(CreateNotificationCommand command)
    {
        var notification = Notification.Create(command.Title, command.Message, command.Recipient);
        
        //await _notificationsRepository.AddNotificationAsync(notification);

        await _messagePublisher.PublishAsync(new NotificationCreated(notification.Id, command.Channel));
        
        return notification.Id;
    }
}