using Barbershop.Scheduling.Models;
using Barbershop.Scheduling.Queries;
using Barbershop.Scheduling.Services;
using MediatR;

namespace Barbershop.Scheduling.Handlers;

public class FindAllAppointmentsQueryHandler :IRequestHandler<FindAllAppointmentsQuery,IEnumerable<Appointment>>
{
    private readonly IAppointmentService _appointmentService;

    public FindAllAppointmentsQueryHandler(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    public async Task<IEnumerable<Appointment>> Handle(FindAllAppointmentsQuery request, CancellationToken cancellationToken)
    {
        
        var result = await _appointmentService.GetAllAppointmentsAsync();
        return result;
    }
}