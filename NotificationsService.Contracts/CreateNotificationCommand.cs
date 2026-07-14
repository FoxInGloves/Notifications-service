namespace NotificationsService.Contracts;

public sealed record CreateNotificationCommand(
    string Recipient,
    string Title,
    string Message);