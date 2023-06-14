namespace Barbershop.Contracts.Events;

public interface CustomerDeleted
{
    public Guid CustomerId { get; set; }
    
}