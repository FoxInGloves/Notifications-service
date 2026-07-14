namespace NotificationsService.Domain;

public class Notification
{
    public Guid Id { get; private set; }
    
    public string Title { get; set; }
    
    public string Message { get; set; }
    
    public string Recipient { get; set; }
    
    private Notification(string title, string message, string recipient)
    {
        Id = Guid.NewGuid();
        Title = title;
        Message = message;
        Recipient = recipient;
    }
    
    public static Notification Create(string title, string message, string recipient)
    {
        return new Notification(title, message, recipient);
    } 
}