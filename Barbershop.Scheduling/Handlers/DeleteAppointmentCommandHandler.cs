using Barbershop.Contracts.Events;
using Barbershop.Scheduling.Commands;
using Barbershop.Scheduling.Services;
using MassTransit;
using MediatR;

namespace Barbershop.Scheduling.Handlers;

public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand,bool>
{
    private readonly IAppointmentService _appointmentService;
    private readonly IPublishEndpoint _publishEndpoint;
    public DeleteAppointmentCommandHandler(IAppointmentService appointmentService, IPublishEndpoint publishEndpoint)
    {
        _appointmentService = appointmentService;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<bool> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointmentInfo =  _appointmentService.GetAppointmentAsync(request.AppointmentId);
        var result = await _appointmentService.DeleteAppointmentAsync(request.AppointmentId);
        if (result)
        {
            _publishEndpoint.Publish<AppointmentDeleted>(values: new
            {
                Id = appointmentInfo.Result.Id,
                CustomerId = appointmentInfo.Result.CustomerId
            });
        }
        return result;
    }
}