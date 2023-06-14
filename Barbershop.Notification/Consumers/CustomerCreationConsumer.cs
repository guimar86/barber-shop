using Barbershop.Contracts.Events;
using MassTransit;
using ILogger = Serilog.ILogger;

namespace Barbershop.Notification.Consumers;

public class CustomerCreationConsumer :IConsumer<CustomerCreated>
{
    private readonly ILogger<CustomerCreationConsumer> _logger;

    public CustomerCreationConsumer(ILogger<CustomerCreationConsumer> logger)
    {
        _logger = logger;
    }
    
    public async Task Consume(ConsumeContext<CustomerCreated> context)
    {
        _logger.LogInformation($" Customer has been created and will be notified by email {context.Message.CustomerId}");
    }
}