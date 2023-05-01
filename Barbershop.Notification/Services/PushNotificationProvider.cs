using Barbershop.Notification.Models;

namespace Barbershop.Notification.Services;

public class PushNotificationProvider : IPushNotificationProvider
{
    
    public async Task<bool> SendNotificationAsync(NotificationDto notificationDto)
    {
        return  false;
    }
}