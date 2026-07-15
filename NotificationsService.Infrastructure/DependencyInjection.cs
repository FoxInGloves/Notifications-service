using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationsService.Application.Abstractions;
using NotificationsService.Infrastructure.Messaging;
using NotificationsService.Infrastructure.Repository;

namespace NotificationsService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRabbitMqConnection, RabbitMqConnection>();
        services.Configure<RabbitMqOptions>(configuration.GetSection("RabbitMq"));
        services.AddScoped<IMessagePublisher, RabbitMqMessagePublisher>();

        services.AddScoped<INotificationsRepository, EFRepository>();
        
        return services;
    }
}