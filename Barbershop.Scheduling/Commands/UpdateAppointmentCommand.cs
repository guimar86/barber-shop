using Barbershop.Scheduling.Models;
using MediatR;

namespace Barbershop.Scheduling.Commands;

public class UpdateAppointmentCommand :IRequest<Appointment>
{
    public UpdateAppointmentCommand(Appointment appointment)
    {
        Appointment = appointment;
    }

    public Appointment Appointment { get;}
    
}