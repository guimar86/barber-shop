using Barbershop.Notification.Models;

namespace Barbershop.Notification.Services;

public interface INotificationProvider
{
    Task<bool> SendNotificationAsync(NotificationDto notificationDto);
}