using Barbershop.Contracts.Events;
using MassTransit;
using ILogger = Serilog.ILogger;

namespace Barbershop.Notification.Consumers;

public class AppointmentCreatedConsumer:IConsumer<IAppointmentCreated>
{
    private readonly ILogger _logger;
    
    public AppointmentCreatedConsumer(ILogger logger)
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<IAppointmentCreated> context)
    {
        _logger.Information("Appointment has been created {appointment}",context.Message);
    }
}