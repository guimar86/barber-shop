using Barbershop.Scheduling.Commands;
using Barbershop.Scheduling.Services;
using MediatR;

namespace Barbershop.Scheduling.Handlers;

public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand,bool>
{
    private readonly IAppointmentService _appointmentService;

    public DeleteAppointmentCommandHandler(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    public async Task<bool> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var result = await _appointmentService.DeleteAppointmentAsync(request.AppointmentId);
        return result;
    }
}