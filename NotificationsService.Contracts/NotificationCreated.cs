namespace NotificationsService.Contracts;

public class NotificationCreated
{
    public Guid Id { get; private set; }
    
    public NotificationCreated(Guid id)
    {
        Id = id;
    }
}