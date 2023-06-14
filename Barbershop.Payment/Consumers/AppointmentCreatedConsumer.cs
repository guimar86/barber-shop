using Barbershop.Contracts.Events;
using MassTransit;
using ILogger = Serilog.ILogger;

namespace Barbershop.Payment.Consumers;

public class AppointmentCreatedConsumer : IConsumer<IAppointmentCreated>
{
    private readonly ILogger _logger;

    public AppointmentCreatedConsumer(ILogger logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<IAppointmentCreated> context)
    {
       _logger.Information("Appointment created. Payment will be processed {appointment}",context.Message);
    }
}