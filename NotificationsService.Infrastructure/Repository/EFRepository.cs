using NotificationsService.Application.Abstractions;
using NotificationsService.Domain;

namespace NotificationsService.Infrastructure.Repository;

public class EFRepository : INotificationsRepository
{
    public Task GetNotificationsAsync()
    {
        throw new NotImplementedException();
    }

    public Task GetNotificationByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddNotificationAsync(Notification notification)
    {
        throw new NotImplementedException();
    }

    public Task UpdateNotificationAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteNotificationAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}