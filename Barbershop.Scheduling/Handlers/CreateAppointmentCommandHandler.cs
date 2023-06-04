using Barbershop.Contracts.Events;
using Barbershop.Scheduling.Commands;
using Barbershop.Scheduling.Models;
using Barbershop.Scheduling.Services;
using MassTransit;
using MediatR;

namespace Barbershop.Scheduling.Handlers;

public class CreateAppointmentCommandHandler :IRequestHandler<CreateAppointmentCommand, Appointment>
{
    private readonly IAppointmentService _appointmentService;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateAppointmentCommandHandler(IAppointmentService appointmentService, IPublishEndpoint publishEndpoint)
    {
        _appointmentService = appointmentService;
        _publishEndpoint = publishEndpoint;
    }


    public async Task<Appointment> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var result= await _appointmentService.CreateAppointmentAsync(request.Appointment);
        await _publishEndpoint.Publish<IAppointmentCreated>(values: result,cancellationToken);
        return result;
    }
}