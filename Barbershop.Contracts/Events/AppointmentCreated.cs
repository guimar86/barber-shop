namespace Barbershop.Contracts.Events;

public interface IAppointmentCreated
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime StartTime { get; set; }
    public int DurationInMinutes { get; set; }
    public string BarberName { get; set; }
    public DateTime EndDateTime { get; set; }
    public bool IsCancelled { get; set; }
}