using Barbershop.Contracts.Events;
using Barbershop.Scheduling.Commands;
using Barbershop.Scheduling.Models;
using Barbershop.Scheduling.Services;
using MassTransit;
using MediatR;
using ILogger = Serilog.ILogger;

namespace Barbershop.Scheduling.Handlers;

public class UpdateAppointmentCommandHandler :IRequestHandler<UpdateAppointmentCommand,Appointment>
{
    private readonly IAppointmentService _appointmentService;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger _logger;
    public UpdateAppointmentCommandHandler(IAppointmentService appointmentService, ILogger logger, IPublishEndpoint publishEndpoint)
    {
        _appointmentService = appointmentService;
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<Appointment> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var result = await _appointmentService.UpdateAppointmentAsync(request.Appointment);
        if (result!=null)
        {

            try
            {
                await _publishEndpoint.Publish<AppointmentUpdated>(values:result, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.Error("Error while sending appointment update message {error} ",e);
                _logger.Error(e.StackTrace);
            }
        }
        return result;
    }
}