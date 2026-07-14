using NotificationsService.Domain;

namespace NotificationsService.Application.Abstractions;

public interface INotificationsRepository
{
    public Task GetNotificationsAsync();
    
    public Task GetNotificationByIdAsync(Guid id);
    
    public Task AddNotificationAsync(Notification notification);
    
    public Task UpdateNotificationAsync(Guid id);
    
    public Task DeleteNotificationAsync(Guid id);
}