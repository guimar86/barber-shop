using Barbershop.Scheduling.Models;
using Barbershop.Scheduling.Queries;
using Barbershop.Scheduling.Services;
using MediatR;

namespace Barbershop.Scheduling.Handlers;

public class FindAppointmentsByDateQueryHandler :IRequestHandler<FindAppointmentsByDateQuery,IEnumerable<Appointment>>
{
    private readonly IAppointmentService _appointmentService;
    
    public async Task<IEnumerable<Appointment>> Handle(FindAppointmentsByDateQuery request, CancellationToken cancellationToken)
    {
        var result = await _appointmentService.GetAppointmentsForDateAsync(request.AppointmentDate);
        return result;
    }
}