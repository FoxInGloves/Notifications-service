namespace NotificationsService.Contracts;

public class NotificationCreated
{
    public Guid Id { get; }
    
    public NotificationChannelEnum Channel { get; }
    
    public NotificationCreated(Guid id, NotificationChannelEnum channel)
    {
        Id = id;
        Channel = channel;
    }
}