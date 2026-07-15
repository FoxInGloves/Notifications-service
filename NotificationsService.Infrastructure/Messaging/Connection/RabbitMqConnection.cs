using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace NotificationsService.Infrastructure.Messaging;

public class RabbitMqConnection : IRabbitMqConnection
{
    private readonly ConnectionFactory _connectionFactory;
    private IConnection? _connection;

    public RabbitMqConnection(IOptions<RabbitMqOptions> rabbitMqOptions)
    {
        var options = rabbitMqOptions.Value;
        
        _connectionFactory = new ConnectionFactory
        {
            HostName = options.Host, 
            Port = options.Port, 
            UserName = options.User,
            Password = options.Password
        };
    }
    
    public async Task<IConnection> GetConnectionAsync()
    {
        if (_connection is { IsOpen: true })
            return _connection;
        
        _connection = await _connectionFactory.CreateConnectionAsync();
        
        return _connection;
    }
}