using Barbershop.Payment.Models;

namespace Barbershop.Payment.Services;

public interface IPaymentService
{
    Task<Models.Payment> ProcessPaymentAsync(Models.Payment paymentRequest);
    Task<Models.Payment> GetPaymentAsync(string paymentId);
    Task<IEnumerable<Models.Payment>> GetPaymentsByCustomerAsync(string CustomerId);
    Task<bool> RefundPaymentAsync(string paymentId);
    Task<bool> CancelPaymentAsync(string paymentId);
}
