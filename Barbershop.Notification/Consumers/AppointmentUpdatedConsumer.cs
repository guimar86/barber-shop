using Barbershop.Contracts.Events;
using MassTransit;
using ILogger = Serilog.ILogger;

namespace Barbershop.Notification.Consumers;

public class AppointmentUpdatedConsumer :IConsumer<AppointmentUpdated>
{
    private readonly ILogger _logger;

    public AppointmentUpdatedConsumer(ILogger logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<AppointmentUpdated> context)
    {
        _logger.Information("Appointment {appointmentId} has been updated successfully. Client will be notified.",context.Message.Id);
    }
}