using Barbershop.Contracts.Events;
using BarberShop.Management.Commands;
using BarberShop.Management.Services;
using MassTransit;
using MediatR;

namespace BarberShop.Management.Handlers;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand,bool>
{
    private readonly ICustomer _customerService;
    private readonly ISendEndpointProvider _endpointProvider;

    public DeleteCustomerCommandHandler(ICustomer customerService, ISendEndpointProvider endpointProvider)
    {
        _customerService = customerService;
        _endpointProvider = endpointProvider;
    }

    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var result= await _customerService.DeleteCustomerAsync(request.CustomerId);
        if (!result) return result;
        var endpoint=await _endpointProvider.GetSendEndpoint(new Uri("queue:customer-deleted-queue"));
        await endpoint.Send<CustomerDeleted>(new
        {
            CustomerId = request.CustomerId
        },cancellationToken);
        
        return result;
    }
}