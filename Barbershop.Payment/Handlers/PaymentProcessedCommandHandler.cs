using Barbershop.Payment.Commands;
using Barbershop.Payment.Services;
using MediatR;
using ILogger = Serilog.ILogger;

namespace Barbershop.Payment.Handlers;

public class PaymentProcessedCommandHandler :IRequestHandler<PaymentProcessedCommand,Models.Payment>
{
    private readonly IPaymentService _paymentService;
    private readonly ILogger _logger;
    public PaymentProcessedCommandHandler(IPaymentService paymentService, ILogger logger)
    {
        _paymentService = paymentService;
        _logger = logger;
    }

    public async Task<Models.Payment> Handle(PaymentProcessedCommand request, CancellationToken cancellationToken)
    {
        _logger.Information("Payment process {payment} ",request.Payment);
        var result = await _paymentService.ProcessPaymentAsync(request.Payment);
        return result;
    }
}