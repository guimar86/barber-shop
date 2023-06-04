using Barbershop.Scheduling.Commands;
using Barbershop.Scheduling.Models;
using Barbershop.Scheduling.Queries;
using Barbershop.Scheduling.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop.Scheduling.Controllers;

[ApiController]
[Route("[controller]")]
public class SchedulingController : ControllerBase
{
    private readonly ISender _mediator;
    public SchedulingController(IAppointmentService appointmentService, ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Appointment appointment)
    {
        try
        {
            var command = new CreateAppointmentCommand(appointment);
            var result =  await _mediator.Send(command);
            return Created("",result);
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
    public async Task<IActionResult> Update([FromBody] Appointment appointment)
    {
        try
        {
            var command = new UpdateAppointmentCommand(appointment);
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
    [Route("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            var command = new DeleteAppointmentCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
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
            var query = new FindAppointmentByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
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
            var query = new FindAllAppointmentsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
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
            var query = new FindAppointmentsByDateQuery(date);
            var result = await _mediator.Send(query);
            return Ok(result);
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
            var query = new FindAppointmentsByCustomerQuery(customerId);
            var result = await _mediator.Send(query);
            return Ok(result);
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