using Microsoft.AspNetCore.Mvc;
using NotificationsService.Application;
using NotificationsService.Application.Abstractions;
using NotificationsService.Contracts;
using NotificationsService.Domain;

namespace NotificationsService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly NotificationService _notificationService;

    public NotificationsController(NotificationService notificationService)
    {
        _notificationService = notificationService;
    }

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
    public async Task<IActionResult> Post([FromBody] CreateNotificationCommand command)
    {
        var notificationId = await _notificationService.CreateNotificationAsync(command);

        return Accepted(new { NotificationId = notificationId });
    }
}