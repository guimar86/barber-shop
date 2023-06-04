using MediatR;

namespace Barbershop.Payment.Commands;

public class PaymentRefundCommand :IRequest<bool>
{
    public PaymentRefundCommand(string paymentId)
    {
        PaymentId = paymentId;
    }

    public string PaymentId { get;}
    
}