using MediatR;

namespace Barbershop.Payment.Queries;

public class FindPaymentByIdQuery:IRequest<Models.Payment>
{
    public FindPaymentByIdQuery(string paymentId)
    {
        PaymentId = paymentId;
    }

    public string PaymentId { get; set; }
    
}