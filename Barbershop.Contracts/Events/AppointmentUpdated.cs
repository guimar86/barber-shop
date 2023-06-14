namespace Barbershop.Contracts.Events;

public interface AppointmentUpdated
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public int DurationInMinutes { get; set; }
    public string BarberName { get; set; }
    public bool IsCancelled { get; set; }
}