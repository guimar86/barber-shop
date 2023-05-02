namespace Barbershop.Scheduling.Models;

public class Appointment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CustomerId { get; set; }
    private DateTime startTime;
    public DateTime StartTime
    {
        get => startTime;
        set
        {
            startTime = value;
            EndDateTime = startTime.AddMinutes(DurationInMinutes);
        }
    }
    private int durationInMinutes;
    public int DurationInMinutes
    {
        get => durationInMinutes;
        set
        {
            durationInMinutes = value;
            EndDateTime = startTime.AddMinutes(durationInMinutes);
        }
    }
    public string BarberName { get; set; }
    public DateTime EndDateTime { get; private set; }
    public bool IsCancelled { get; set; }
}

