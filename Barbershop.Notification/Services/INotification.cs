using Barbershop.Notification.Models;

namespace Barbershop.Notification.Services;

public interface INotification
{
    Task<bool> SendNotificationAsync(NotificationType notificationType,NotificationDto notificationDto);
}