namespace Barbershop.Payment.Models;

public class Payment
{
    public Guid Id { get; set; } = Guid.NewGuid(); // Unique identifier for the payment
    public decimal Amount { get; set; } // Total amount of the payment
    public string Currency { get; set; } // Currency of the payment (e.g. "USD")
    public string Description { get; set; } // Description of the payment
    public DateTime Created { get; set; } // Timestamp of when the payment was created
    public PaymentStatus Status { get; set; } // Current status of the payment (e.g. "Pending", "Complete", "Failed")
    public PaymentMethod PaymentMethod { get; set; } // Payment method used for the transaction (e.g. "Credit Card", "PayPal", "Apple Pay")
    public string CustomerId { get; set; } // ID of the customer associated with the payment (if any)
    public string OrderId { get; set; } // ID of the order associated with the payment (if any)
    public string TransactionId { get; set; } // ID of the payment transaction (if available)
    public Provider Provider { get; set; } // Payment provider used for the transaction (e.g. "Stripe", "PayPal", "Authorize.Net")
}
