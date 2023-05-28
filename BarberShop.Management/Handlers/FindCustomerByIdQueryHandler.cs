using BarberShop.Management.Models;
using BarberShop.Management.Queries;
using BarberShop.Management.Services;
using MediatR;

namespace BarberShop.Management.Handlers;

public class FindCustomerByIdQueryHandler : IRequestHandler<FindCustomerById,Customer>
{
    private readonly ICustomer _customerService;

    public FindCustomerByIdQueryHandler(ICustomer customerService)
    {
        _customerService = customerService;
    }

    public async Task<Customer> Handle(FindCustomerById request, CancellationToken cancellationToken)
    {
        var customer=await _customerService.GetCustomerAsync(request.CustomerId);

        return customer;
    }
}