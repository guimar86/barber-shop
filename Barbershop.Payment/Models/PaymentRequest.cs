namespace Barbershop.Payment.Models;

public class PaymentRequest
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string CardNumber { get; set; }
    public string ExpiryMonth { get; set; }
    public string ExpiryYear { get; set; }
    public string Cvv { get; set; }
}
