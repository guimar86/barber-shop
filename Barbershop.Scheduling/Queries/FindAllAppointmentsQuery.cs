using Barbershop.Scheduling.Models;
using MediatR;

namespace Barbershop.Scheduling.Queries;

public class FindAllAppointmentsQuery :IRequest<IEnumerable<Appointment>>
{
    
}