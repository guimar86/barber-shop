using Barbershop.Scheduling.Models;
using Barbershop.Scheduling.Queries;
using Barbershop.Scheduling.Services;
using MediatR;

namespace Barbershop.Scheduling.Handlers;

public class FindAppointmentsByCustomerQueryHandler :IRequestHandler<FindAppointmentsByCustomerQuery,IEnumerable<Appointment>>
{
    private readonly IAppointmentService _appointmentService;

    public FindAppointmentsByCustomerQueryHandler(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    public async Task<IEnumerable<Appointment>> Handle(FindAppointmentsByCustomerQuery request, CancellationToken cancellationToken)
    {
        var result = await _appointmentService.GetAppointmentsForCustomerAsync(request.CustomerId);
        return result;
    }
}