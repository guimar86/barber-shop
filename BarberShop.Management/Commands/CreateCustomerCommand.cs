using BarberShop.Management.Models;
using MediatR;

namespace BarberShop.Management.Commands;

public class CreateCustomerCommand: IRequest<Customer>
{
    public Customer Customer { get; }
    public CreateCustomerCommand(Customer customer)
    {
        Customer = customer;
    }
}