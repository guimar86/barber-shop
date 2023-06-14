using MediatR;

namespace Barbershop.Payment.Queries;

public class FindPaymentsByCustomerQuery:IRequest<IEnumerable<Models.Payment>>
{
    public FindPaymentsByCustomerQuery(string customerId)
    {
        CustomerId = customerId;
    }

    public string CustomerId { get; set; }
}