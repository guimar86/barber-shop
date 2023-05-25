using System.Net;
using Barbershop.Scheduling.Models;
using Barbershop.Scheduling.Services;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace Barbershop.Scheduling.Controllers;

[ApiController]
[Route("[controller]")]
public class SchedulingController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;
    private readonly ILogger<SchedulingController> _logger;

    public SchedulingController(IAppointmentService appointmentService, ILogger<SchedulingController> logger)
    {
        _appointmentService = appointmentService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Appointment appointment)
    {
        try
        {
            _logger.LogInformation("Create schedule {appointment}", appointment);
            var url = Url.Action(nameof(FindById), appointment.Id);
            return Created("", await _appointmentService.CreateAppointmentAsync(appointment));
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            var problemDetails = new ProblemDetails
            {
                Title = e.Message.GetType().Name,
                Detail = e.Message
            };
            return StatusCode(500, problemDetails);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Appointment appointment)
    {
        try
        {
            return Ok(await _appointmentService.UpdateAppointmentAsync(appointment));
        }
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.Message.GetType().Name,
                Detail = e.Message
            };
            return StatusCode(500, problemDetails);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            return Ok(await _appointmentService.DeleteAppointmentAsync(id));
        }
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.Message.GetType().Name,
                Detail = e.Message
            };
            return StatusCode(500, problemDetails);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> FindById(string id)
    {
        try
        {
            return Ok(await _appointmentService.GetAppointmentAsync(id));
        }
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.Message.GetType().Name,
                Detail = e.Message
            };
            return StatusCode(500, problemDetails);
        }
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        try
        {
            _logger.LogInformation("List all schedule services");
            return Ok(await _appointmentService.GetAllAppointmentsAsync());
        }
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.Message.GetType().Name,
                Detail = e.Message
            };
            return StatusCode(500, problemDetails);
        }
    }

    [HttpGet]
    [Route("/date/{date}")]
    public async Task<IActionResult> FindByDate(string date)
    {
        try
        {
            return Ok(await _appointmentService.GetAppointmentsForDateAsync(date));
        }
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.Message.GetType().Name,
                Detail = e.Message
            };
            return StatusCode(500, problemDetails);
        }
    }

    [HttpGet]
    [Route("/customer/{customerId}")]
    public async Task<IActionResult> FindByCustomer([FromRoute] string customerId)
    {
        try
        {
            return Ok(await _appointmentService.GetAppointmentsForCustomerAsync(customerId));
        }
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.Message.GetType().Name,
                Detail = e.Message
            };
            return StatusCode(500, problemDetails);
        }
    }
    
    
}