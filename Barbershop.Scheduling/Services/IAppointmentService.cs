using Barbershop.Scheduling.Models;

namespace Barbershop.Scheduling.Services;

public interface IAppointmentService
{
    Task<Appointment> CreateAppointmentAsync(Appointment appointment);
    Task<Appointment> GetAppointmentAsync(string appointmentId);
    Task<IEnumerable<Appointment>> GetAppointmentsForDateAsync(string date);
    Task<IEnumerable<Appointment>> GetAppointmentsForCustomerAsync(string customerId);
    Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
    Task<Appointment> UpdateAppointmentAsync(Appointment appointment);
    Task<bool> DeleteAppointmentAsync(string appointmentId);
}