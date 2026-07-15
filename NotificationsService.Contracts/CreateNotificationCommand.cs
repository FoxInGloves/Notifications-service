namespace NotificationsService.Contracts;

public sealed record CreateNotificationCommand(
    string Recipient,
    NotificationChannelEnum Channel,
    string Title,
    string Message);