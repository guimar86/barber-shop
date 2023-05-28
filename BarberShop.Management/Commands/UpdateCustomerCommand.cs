using BarberShop.Management.Models;
using MediatR;

namespace BarberShop.Management.Commands;

public class UpdateCustomerCommand:IRequest<Customer>
{
    public Customer Customer { get;}
    
    public UpdateCustomerCommand(Customer customer)
    {
        Customer = customer;
    }
}