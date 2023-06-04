namespace Barbershop.Contracts.Events;

public interface AppointmentDeleted
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
}