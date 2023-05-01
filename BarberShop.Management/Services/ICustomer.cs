using BarberShop.Management.Models;

namespace BarberShop.Management.Services;

public interface ICustomer
{
    Task<Customer> CreateCustomerAsync(Customer customer);
    Task<Customer> GetCustomerAsync(string customerId);
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer> UpdateCustomerAsync(Customer customer);
    Task<bool> DeleteCustomerAsync(string customerId);
}