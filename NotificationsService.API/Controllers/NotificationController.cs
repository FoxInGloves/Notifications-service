using Microsoft.AspNetCore.Mvc;
using NotificationsService.Application;
using NotificationsService.Application.Abstractions;
using NotificationsService.Contracts;
using NotificationsService.Domain;

namespace NotificationsService.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly NotificationService _notificationService;
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Created();
    }

    [HttpGet("{id:guid}")]  
    public Task Get(Guid id)
    {
        return Task.CompletedTask;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateNotificationCommand command)
    {
        var notificationId = await _notificationService.CreateNotificationAsync(command);
        
        return Accepted(new { NotificationId = notificationId });
    }
}