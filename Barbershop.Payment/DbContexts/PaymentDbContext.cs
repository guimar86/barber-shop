using Microsoft.EntityFrameworkCore;

namespace Barbershop.Payment.DbContexts;

public class PaymentDbContext : DbContext
{
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
    {
        
    }

    public DbSet<Models.Payment> Payments { get; set; }
}