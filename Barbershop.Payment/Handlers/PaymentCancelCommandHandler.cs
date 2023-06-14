using Barbershop.Payment.Commands;
using Barbershop.Payment.Services;
using MediatR;

namespace Barbershop.Payment.Handlers;

public class PaymentCancelCommandHandler :IRequestHandler<PaymentCancelCommand,bool>
{
    private readonly IPaymentService _paymentService;

    public PaymentCancelCommandHandler(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public async Task<bool> Handle(PaymentCancelCommand request, CancellationToken cancellationToken)
    {
        var result = await _paymentService.CancelPaymentAsync(request.PaymentId);
        return result;
    }
}