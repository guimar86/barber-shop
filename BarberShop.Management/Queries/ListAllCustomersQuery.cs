using BarberShop.Management.Models;
using MediatR;

namespace BarberShop.Management.Queries;

public class ListAllCustomersQuery:IRequest<IEnumerable<Customer>>
{
    
}