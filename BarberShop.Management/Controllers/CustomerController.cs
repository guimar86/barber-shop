using BarberShop.Management.Commands;
using BarberShop.Management.Models;
using BarberShop.Management.Queries;
using BarberShop.Management.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Management.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(ICustomer customerService, IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        try
        {
            var query = new ListAllCustomersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.GetType().FullName,
                Status = StatusCodes.Status500InternalServerError,
                Detail = e.Message
            };

            return StatusCode(500, problemDetails);
        }
    }

    [HttpGet]
    [Route("{customerId}")]
    public async Task<IActionResult> Find(string customerId)
    {
        try
        {
            var query = new FindCustomerById(customerId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.GetType().FullName,
                Status = StatusCodes.Status500InternalServerError,
                Detail = e.Message
            };

            return StatusCode(500, problemDetails);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Customer customer)
    {
        try
        {
            var command = new UpdateCustomerCommand(customer);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.GetType().FullName,
                Status = StatusCodes.Status500InternalServerError,
                Detail = e.Message
            };

            return StatusCode(500, problemDetails);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Customer customer)
    {
        try
        {
            var command = new CreateCustomerCommand(customer);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.GetType().FullName,
                Status = StatusCodes.Status500InternalServerError,
                Detail = e.Message
            };

            return StatusCode(500, problemDetails);
        }
    }

    [HttpDelete]
    [Route("{customerId}")]
    public async Task<IActionResult> Delete(string customerId)
    {
        try
        {
            var command = new DeleteCustomerCommand(customerId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.GetType().FullName,
                Status = StatusCodes.Status500InternalServerError,
                Detail = e.Message
            };

            return StatusCode(500, problemDetails);
        }
    }
}