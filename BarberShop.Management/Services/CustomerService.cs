using BarberShop.Management.DbContexts;
using BarberShop.Management.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Management.Services;

public class CustomerService : ICustomer
{
    private readonly ApplicationDbContext _dbContext;

    public CustomerService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        try
        {
            _dbContext.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Customer> GetCustomerAsync(string customerId)
    {
        try
        {
            var foundCustomer= await _dbContext.Customers.Where(customer => customer.Id.ToString().Equals(customerId)).FirstOrDefaultAsync();

            return foundCustomer;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        try
        {
            var allCustomers =await _dbContext.Customers.ToListAsync();
            return allCustomers;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Customer> UpdateCustomerAsync(Customer customer)
    {
        try
        {
            var inDbCustomer = _dbContext.Customers.FirstOrDefault(p => p.Id.ToString().Equals(customer.Id.ToString()));

            if (inDbCustomer!=null)
            {
                _dbContext.Entry(inDbCustomer).CurrentValues.SetValues(customer);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                _dbContext.Add(customer);
            }

            return customer;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> DeleteCustomerAsync(string customerId)
    {
        try
        {
            var inDbCustomer = await _dbContext.Customers.FirstOrDefaultAsync(p => p.Id.ToString().Equals(customerId));

            if (inDbCustomer == null) return false;
            _dbContext.Customers.Remove(inDbCustomer);
            await _dbContext.SaveChangesAsync();
            return true;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}