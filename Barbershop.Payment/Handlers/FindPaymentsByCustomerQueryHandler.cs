using Barbershop.Payment.Queries;
using Barbershop.Payment.Services;
using MediatR;

namespace Barbershop.Payment.Handlers;

public class FindPaymentsByCustomerQueryHandler :IRequestHandler<FindPaymentsByCustomerQuery,IEnumerable<Models.Payment>>
{
    private readonly IPaymentService _paymentService;

    public FindPaymentsByCustomerQueryHandler(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }


    public async Task<IEnumerable<Models.Payment>> Handle(FindPaymentsByCustomerQuery request, CancellationToken cancellationToken)
    {
        var result = await _paymentService.GetPaymentsByCustomerAsync(request.CustomerId);
        return result;
    }
}