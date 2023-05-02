using System.Globalization;
using Barbershop.Scheduling.DbContexts;
using Barbershop.Scheduling.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.Scheduling.Services;

public class AppointmentService : IAppointmentService
{
    private readonly SchedulingDbContext _dbContext;

    public AppointmentService(SchedulingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
    {
        
        // Check if there is already an appointment with the same barber that overlaps with the new appointment
        if (_dbContext.Appointments.Any(a=>appointment.StartTime>a.StartTime && appointment.StartTime < a.EndDateTime))
        {
            throw new InvalidOperationException(
                "There is already an appointment that overlaps with the selected barber's schedule.");
        }

        // Check if the customer has any appointments that overlap with the new appointment
        if (_dbContext.Appointments.Any(a => a.CustomerId == appointment.CustomerId &&
                                   a.StartTime < appointment.EndDateTime && a.EndDateTime > appointment.StartTime))
        {
            throw new InvalidOperationException(
                "The customer already has an appointment that overlaps with the selected time.");
        }

        _dbContext.Add(appointment);
        await _dbContext.SaveChangesAsync();

        return appointment;
    }

    public async Task<Appointment> GetAppointmentAsync(string appointmentId)
    {
        try
        {
            return await _dbContext.Appointments.FirstOrDefaultAsync(p => p.Id.ToString().Equals(appointmentId));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsForDateAsync(string dateString)
    {
        try
        {
            var date = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
            return _dbContext.Appointments.Where(p => p.StartTime.ToUniversalTime().Date == date).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsForCustomerAsync(string customerId)
    {
        return _dbContext.Appointments.Where(p => p.CustomerId.ToString().Equals(customerId)).ToList();
    }

    public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
    {
        return _dbContext.Appointments.ToList();
    }

    public async Task<Appointment> UpdateAppointmentAsync(Appointment appointment)
    {
        var existingAppointment = await _dbContext.Appointments.FirstOrDefaultAsync(a => a.Id == appointment.Id);
        if (existingAppointment == null)
        {
            throw new InvalidOperationException("Appointment not found.");
        }

       
        // Check if there is already an appointment with the same barber that overlaps with the updated appointment
        if (_dbContext.Appointments.Any(a=>appointment.StartTime>a.StartTime && appointment.StartTime < a.EndDateTime))
        {
            throw new InvalidOperationException(
                "There is already an appointment that overlaps with the selected barber's schedule.");
        }

        // Check if the customer has any appointments that overlap with the updated appointment
        if (_dbContext.Appointments.Any(a=>a.CustomerId==appointment.CustomerId && (appointment.StartTime>a.StartTime && appointment.StartTime < a.EndDateTime)))
        {
            throw new InvalidOperationException(
                "The customer already has an appointment that overlaps with the selected time.");
        }

        _dbContext.Entry(existingAppointment).CurrentValues.SetValues(appointment);

        await _dbContext.SaveChangesAsync();

        return existingAppointment;
    }

    public async Task<bool> DeleteAppointmentAsync(string appointmentId)
    {
        try
        {
            var appointment = _dbContext.Appointments.FirstOrDefault(p => p.Id.ToString().Equals(appointmentId));
            if (appointment == null) return false;
            _dbContext.Appointments.Remove(appointment);
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