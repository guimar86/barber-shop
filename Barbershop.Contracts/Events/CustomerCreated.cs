namespace Barbershop.Contracts.Events;

public interface CustomerCreated
{
    Guid CustomerId { get; set; }
}