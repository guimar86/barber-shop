using Barbershop.Contracts.Events;
using MassTransit;
using ILogger = Serilog.ILogger;

namespace Barbershop.Notification.Consumers;

public class CustomerDeletionConsumer:IConsumer<CustomerDeleted>
{
    private readonly ILogger _logger;

    public CustomerDeletionConsumer(ILogger logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<CustomerDeleted> context)
    {
        _logger.Information("Customer {customerId} deleted from Barbershop database",context.Message.CustomerId);
    }
}