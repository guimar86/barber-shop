using BarberShop.Management.Commands;
using BarberShop.Management.Services;
using MediatR;

namespace BarberShop.Management.Handlers;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand,bool>
{
    private readonly ICustomer _customerService;

    public DeleteCustomerCommandHandler(ICustomer customerService)
    {
        _customerService = customerService;
    }

    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        return await _customerService.DeleteCustomerAsync(request.CustomerId);
    }
}