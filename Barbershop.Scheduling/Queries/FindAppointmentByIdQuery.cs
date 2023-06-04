using Barbershop.Scheduling.Models;
using MediatR;

namespace Barbershop.Scheduling.Queries;


public class FindAppointmentByIdQuery :IRequest<Appointment>
{
    public FindAppointmentByIdQuery(string appointmentId)
    {
        AppointmentId = appointmentId;
    }

    public string AppointmentId { get; }
    
}