using BarberShop.Management.Commands;
using BarberShop.Management.Models;
using BarberShop.Management.Services;
using MediatR;

namespace BarberShop.Management.Handlers;

public class CreateCustomerCommandHandler :IRequestHandler<CreateCustomerCommand,Customer>
{
    private readonly ICustomer _customerService;

    public CreateCustomerCommandHandler(ICustomer customerService)
    {
        _customerService = customerService;
    }

    public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        return await _customerService.CreateCustomerAsync(request.Customer);
    }
}