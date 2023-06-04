using Barbershop.Payment.Commands;
using Barbershop.Payment.Queries;
using Barbershop.Payment.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop.Payment.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController: ControllerBase
{
   
    private readonly ISender _mediator;
    public PaymentController(ISender mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> ProcessPayment([FromBody] Models.Payment payment)
    {
        try
        {
            var command = new PaymentProcessedCommand(payment);
            var result = await _mediator.Send(command);
            return Created("", result);
        }
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.GetType().Name,
                Detail = e.Message,
                Status = StatusCodes.Status500InternalServerError
            };
            return StatusCode(500, problemDetails);
        }
    }

    [HttpGet]
    [Route("/{paymentId}")]
    public async Task<IActionResult> GetPayment([FromRoute] string paymentId)
    {
        try
        {
            var query = new FindPaymentByIdQuery(paymentId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.GetType().Name,
                Detail = e.Message,
                Status = StatusCodes.Status500InternalServerError
            };
            return StatusCode(500, problemDetails);
        }
    }
    
    [HttpGet]
    [Route("/customer/{customerId}")]
    public async Task<IActionResult> GetPaymentsByCustomer([FromRoute] string customerId)
    {
        try
        {
            var query = new FindPaymentsByCustomerQuery(customerId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.GetType().Name,
                Detail = e.Message,
                Status = StatusCodes.Status500InternalServerError
            };
            return StatusCode(500, problemDetails);
        }
    }

    [HttpPost]
    [Route("/refund/{paymentId}")]
    public async Task<IActionResult> Refund([FromRoute] string paymentId)
    {
        try
        {
            var command = new PaymentRefundCommand(paymentId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.GetType().Name,
                Detail = e.Message,
                Status = StatusCodes.Status500InternalServerError
            };
            return StatusCode(500, problemDetails);
        }
    }
    
    [HttpPost]
    [Route("/cancel/{paymentId}")]
    public async Task<IActionResult> Cancel([FromRoute] string paymentId)
    {
        try
        {
            var command = new PaymentCancelCommand(paymentId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.GetType().Name,
                Detail = e.Message,
                Status = StatusCodes.Status500InternalServerError
            };
            return StatusCode(500, problemDetails);
        }
    }
    
}