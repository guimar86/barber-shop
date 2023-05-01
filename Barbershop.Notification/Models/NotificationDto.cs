namespace Barbershop.Notification.Models;

public class NotificationDto
{
    public string Recipient { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public NotificationType NotificationType { get; set; }
}