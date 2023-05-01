using Barbershop.Notification.Models;
using ILogger = Serilog.ILogger;

namespace Barbershop.Notification.Services;

public class SmsNotificationProvider : ISmsNotificationProvider
{

    private readonly IConfiguration _configuration;

    public SmsNotificationProvider(ILogger logger, IConfiguration configuration)
    {
        
        _configuration = configuration;
    }

    public async Task<bool> SendNotificationAsync(NotificationDto notificationDto)
    {
        var apiKey = _configuration["Notification:smsApiKey"];
        const string textbeltEndpoint = "https://textbelt.com/text";
        
        
        using var client = new HttpClient();
        var data = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("phone", notificationDto.Recipient),
            new KeyValuePair<string, string>("message", notificationDto.Subject),
            new KeyValuePair<string, string>("key", apiKey)
        });

        var response = await client.PostAsync(textbeltEndpoint, data);
        var result = await response.Content.ReadAsStringAsync();

        return result.Contains("success");
      
    }
}