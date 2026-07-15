using Microsoft.Extensions.DependencyInjection;
using NotificationsService.Application.Abstractions;

namespace NotificationsService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<NotificationService>();

        return services;
    }
}