using MediatR;

namespace Barbershop.Payment.Commands;

public class PaymentCancelCommand:IRequest<bool>
{
    public PaymentCancelCommand(string paymentId)
    {
        PaymentId = paymentId;
    }

    public string PaymentId { get;}
    
}