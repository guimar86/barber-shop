using BarberShop.Management.Models;
using BarberShop.Management.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Management.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{

    private readonly ICustomer _customerService;

    public CustomerController(ICustomer customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        try
        {
            return Ok(await _customerService.GetAllCustomersAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet]
    [Route("{customerId}")]
    public async Task<IActionResult> Find(string customerId)
    {
        try
        {
            return Ok(await _customerService.GetCustomerAsync(customerId));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Customer customer)
    {
        try
        {
            return Ok(await _customerService.UpdateCustomerAsync(customer));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Customer customer)
    {
        try
        {
            return Ok(await _customerService.CreateCustomerAsync(customer));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpDelete]
    [Route("{customerId}")]
    public async Task<IActionResult> Delete(string customerId)
    {
        try
        {
            return Ok(await _customerService.DeleteCustomerAsync(customerId));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}