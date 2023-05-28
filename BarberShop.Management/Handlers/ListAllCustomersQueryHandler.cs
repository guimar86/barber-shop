using BarberShop.Management.Models;
using BarberShop.Management.Queries;
using BarberShop.Management.Services;
using MediatR;

namespace BarberShop.Management.Handlers;

public class ListAllCustomersQueryHandler:IRequestHandler<ListAllCustomersQuery, IEnumerable<Customer>>
{
    private readonly ICustomer _customerService;

    public ListAllCustomersQueryHandler(ICustomer customerService)
    {
        _customerService = customerService;
    }
    
    
    public async Task<IEnumerable<Customer>> Handle(ListAllCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _customerService.GetAllCustomersAsync();
    }
}