using Barbershop.Contracts.Events;
using MassTransit;
using ILogger = Serilog.ILogger;

namespace Barbershop.Notification.Consumers;

public class AppointmentDeletedConsumer: IConsumer<AppointmentDeleted>
{
    private readonly ILogger _logger;

    public AppointmentDeletedConsumer(ILogger logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<AppointmentDeleted> context)
    {
        _logger.Information("Appointment deleted successfully. Customer will be notified {appointment}",context.Message.Id);
    }
}