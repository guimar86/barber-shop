using Barbershop.Notification.Models;

namespace Barbershop.Notification.Services;

public class NotificationService : INotification
{
    private readonly IEmailNotificationProvider _emailNotificationProvider;
    private readonly ISmsNotificationProvider _smsNotificationProvider;
    private readonly IPushNotificationProvider _pushNotificationProvider;

    public NotificationService(IEmailNotificationProvider emailNotificationProvider, ISmsNotificationProvider smsNotificationProvider, IPushNotificationProvider pushNotificationProvider)
    {
        _emailNotificationProvider = emailNotificationProvider;
        _smsNotificationProvider = smsNotificationProvider;
        _pushNotificationProvider = pushNotificationProvider;
    }


    public async Task<bool> SendNotificationAsync(NotificationType notificationType,NotificationDto notificationDto)
    {
        switch (notificationType)
        {
            case NotificationType.Email:
                return await _emailNotificationProvider.SendNotificationAsync(notificationDto);
             
            case NotificationType.Sms:
                return await _smsNotificationProvider.SendNotificationAsync(notificationDto);
             
            case NotificationType.Push:
                return await _pushNotificationProvider.SendNotificationAsync(notificationDto);
               
            default:
                throw new ArgumentOutOfRangeException(nameof(notificationType), notificationType, null);
        }
    }
}