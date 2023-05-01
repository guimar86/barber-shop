using Barbershop.Notification.Models;
using Barbershop.Notification.Services;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop.Notification.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotification _notificationService;

    public NotificationController(INotification notificationService)
    {
        _notificationService = notificationService;
    }


    [HttpPost]
    public async Task<IActionResult> SendNotification([FromBody] NotificationDto request)
    {
        try
        {
            await _notificationService.SendNotificationAsync(request.NotificationType, request);
            return Ok();
        }
        catch (Exception e)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Detail = e.Message,
                Status = 500,
                Title = "Failure sending notification"
            };

            return StatusCode(500, problemDetails);
        }
    }
}