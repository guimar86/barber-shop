using Barbershop.Scheduling.Commands;
using Barbershop.Scheduling.Models;
using Barbershop.Scheduling.Services;
using MediatR;

namespace Barbershop.Scheduling.Handlers;

public class UpdateAppointmentCommandHandler :IRequestHandler<UpdateAppointmentCommand,Appointment>
{
    private readonly IAppointmentService _appointmentService;

    public UpdateAppointmentCommandHandler(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    public async Task<Appointment> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var result = await _appointmentService.UpdateAppointmentAsync(request.Appointment);
        return result;
    }
}