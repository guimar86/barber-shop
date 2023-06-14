using Barbershop.Scheduling.Models;
using MediatR;

namespace Barbershop.Scheduling.Commands;

public class DeleteAppointmentCommand :IRequest<bool>
{
    public DeleteAppointmentCommand(string appointmentId)
    {
        this.AppointmentId = appointmentId;
    }

    public string AppointmentId { get;}
    
}