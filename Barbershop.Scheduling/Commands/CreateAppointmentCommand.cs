using Barbershop.Scheduling.Models;
using MediatR;

namespace Barbershop.Scheduling.Commands;

public class CreateAppointmentCommand : IRequest<Appointment>
{
    public CreateAppointmentCommand(Appointment appointment)
    {
        Appointment = appointment;
    }

    public Appointment Appointment { get; }
    
    
}