using BarberShop.Management.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Management.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }

    public DbSet<Customer> Customers { get; set; }
}