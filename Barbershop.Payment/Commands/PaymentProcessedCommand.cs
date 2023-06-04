using MediatR;

namespace Barbershop.Payment.Commands;

public class PaymentProcessedCommand :IRequest<Models.Payment>

{
    public PaymentProcessedCommand(Models.Payment payment)
    {
        Payment = payment;
    }

    public Models.Payment Payment { get; set; } 
    
}