using Barbershop.Scheduling.Models;
using MediatR;

namespace Barbershop.Scheduling.Queries;

public class FindAppointmentsByDateQuery :IRequest<IEnumerable<Appointment>>
{
    public FindAppointmentsByDateQuery(string appointmentDate)
    {
        AppointmentDate = appointmentDate;
    }

    public string AppointmentDate { get; set; }
    
}