using Barbershop.Scheduling.Models;
using MediatR;

namespace Barbershop.Scheduling.Queries;

public class FindAppointmentsByCustomerQuery :IRequest<IEnumerable<Appointment>>
{
    public FindAppointmentsByCustomerQuery(string customerId)
    {
        CustomerId = customerId;
    }

    public string CustomerId { get;}
    
}