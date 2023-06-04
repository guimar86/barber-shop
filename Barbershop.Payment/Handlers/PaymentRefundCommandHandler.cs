using Barbershop.Payment.Commands;
using Barbershop.Payment.Services;
using MediatR;

namespace Barbershop.Payment.Handlers;

public class PaymentRefundCommandHandler:IRequestHandler<PaymentRefundCommand,bool>
{
    private readonly IPaymentService _paymentService;

    public PaymentRefundCommandHandler(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public async Task<bool> Handle(PaymentRefundCommand request, CancellationToken cancellationToken)
    {
        var result = await _paymentService.RefundPaymentAsync(request.PaymentId);
        return result;
    }
}