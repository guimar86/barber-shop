using Barbershop.Payment.Services;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop.Payment.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController: ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }


    [HttpPost]
    public async Task<IActionResult> ProcessPayment([FromBody] Models.Payment payment)
    {
        try
        {
            return Created("", await _paymentService.ProcessPaymentAsync(payment));
        }
        catch (Exception e)
        {
            ProblemDetails problemDetails = new ProblemDetails
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
            return Ok(await _paymentService.GetPaymentAsync(paymentId));
        }
        catch (Exception e)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Title = e.GetType().Name,
                Detail = e.Message,
                Status = StatusCodes.Status500InternalServerError
            };
            return StatusCode(500, problemDetails);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPayments([FromQuery] string startDate,[FromQuery] string endDate)
    {
        try
        {
            return Ok(await _paymentService.GetPaymentsAsync(startDate,endDate));
        }
        catch (Exception e)
        {
            ProblemDetails problemDetails = new ProblemDetails
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
            return Ok(await _paymentService.RefundPaymentAsync(paymentId));
        }
        catch (Exception e)
        {
            ProblemDetails problemDetails = new ProblemDetails
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
            return Ok(await _paymentService.CancelPaymentAsync(paymentId));
        }
        catch (Exception e)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Title = e.GetType().Name,
                Detail = e.Message,
                Status = StatusCodes.Status500InternalServerError
            };
            return StatusCode(500, problemDetails);
        }
    }
    
}