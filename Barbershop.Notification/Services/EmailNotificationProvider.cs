using Barbershop.Notification.Models;
using ILogger = Serilog.ILogger;

namespace Barbershop.Notification.Services;

public class EmailNotificationProvider : IEmailNotificationProvider
{
    
    public async Task<bool> SendNotificationAsync(NotificationDto notificationDto)
    {
        throw new NotImplementedException();
    }
}