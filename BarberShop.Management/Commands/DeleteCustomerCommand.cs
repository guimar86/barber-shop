using MediatR;

namespace BarberShop.Management.Commands;

public class DeleteCustomerCommand : IRequest<bool>
{
    public string CustomerId { get; }
    
    public DeleteCustomerCommand(string customerId)
    {
        CustomerId = customerId;
    }
}