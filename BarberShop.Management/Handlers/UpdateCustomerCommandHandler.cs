using BarberShop.Management.Commands;
using BarberShop.Management.Models;
using BarberShop.Management.Services;
using MediatR;

namespace BarberShop.Management.Handlers;

public class UpdateCustomerCommandHandler:IRequestHandler<UpdateCustomerCommand,Customer>
{
    private readonly ICustomer _customerService;

    public UpdateCustomerCommandHandler(ICustomer customerService)
    { 
        _customerService = customerService;
    }

    public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        return await _customerService.UpdateCustomerAsync(request.Customer);
    }
}