using Barbershop.Scheduling.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.Scheduling.DbContexts;

public class SchedulingDbContext :DbContext
{
    public SchedulingDbContext(DbContextOptions<SchedulingDbContext> options):base(options)
    {
        
    }

    public DbSet<Appointment> Appointments { get; set; }
}