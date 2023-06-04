using Barbershop.Contracts.Events;
using BarberShop.Management.Commands;
using BarberShop.Management.Models;
using BarberShop.Management.Services;
using MassTransit;
using MediatR;

namespace BarberShop.Management.Handlers;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
{
    private readonly ICustomer _customerService;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateCustomerCommandHandler(ICustomer customerService,IPublishEndpoint publishEndpoint)
    {
        _customerService = customerService;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var result = await _customerService.CreateCustomerAsync(request.Customer);
        await _publishEndpoint.Publish<CustomerCreated>(new { CustomerId = request.Customer.Id }, cancellationToken);
        return result;
    }
}