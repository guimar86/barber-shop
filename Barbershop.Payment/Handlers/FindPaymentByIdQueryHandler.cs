using Barbershop.Payment.Queries;
using Barbershop.Payment.Services;
using MediatR;
using ILogger = Serilog.ILogger;

namespace Barbershop.Payment.Handlers;

public class FindPaymentByIdQueryHandler: IRequestHandler<FindPaymentByIdQuery,Models.Payment>
{
    private readonly IPaymentService _paymentService;

    public FindPaymentByIdQueryHandler(IPaymentService paymentService, ILogger logger)
    {
        _paymentService = paymentService;
    }

    public async Task<Models.Payment> Handle(FindPaymentByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _paymentService.GetPaymentAsync(request.PaymentId);
        return result;
    }
}