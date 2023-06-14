using Barbershop.Scheduling.Models;
using Barbershop.Scheduling.Queries;
using Barbershop.Scheduling.Services;
using MediatR;

namespace Barbershop.Scheduling.Handlers;

public class FindAppointmentByIdQueryHandler:IRequestHandler<FindAppointmentByIdQuery,Appointment>
{
    private readonly IAppointmentService _appointmentService;

    public FindAppointmentByIdQueryHandler(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    public async Task<Appointment> Handle(FindAppointmentByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _appointmentService.GetAppointmentAsync(request.AppointmentId);
        return result;
    }
}