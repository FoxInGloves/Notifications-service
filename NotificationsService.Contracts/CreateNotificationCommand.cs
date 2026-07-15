namespace NotificationsService.Contracts;

public sealed record CreateNotificationCommand(
    string Recipient,
    NotificationChannel Channel,
    string Title,
    string Message);