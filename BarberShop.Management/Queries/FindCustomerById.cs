using BarberShop.Management.Models;
using MediatR;

namespace BarberShop.Management.Queries;

public class FindCustomerById:IRequest<Customer>
{
    public string CustomerId { get; }
    
    public FindCustomerById(string customerId)
    {
        this.CustomerId = customerId;
    }
}