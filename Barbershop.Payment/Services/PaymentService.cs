using System.Globalization;
using Barbershop.Payment.DbContexts;
using Barbershop.Payment.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.Payment.Services;

public class PaymentService : IPaymentService
{
    private readonly PaymentDbContext _dbContext;

    public PaymentService(PaymentDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Process payment and save it to local database
    /// </summary>
    /// <param name="payment"></param>
    /// <returns></returns>
    public async Task<Models.Payment> ProcessPaymentAsync(Models.Payment payment)
    {
        //process payment with specific provider

        //save information in local database
        try
        {
            _dbContext.Payments.Add(payment);
            await _dbContext.SaveChangesAsync();
            return payment;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Payment retrieval, first from service provider, if it fails then from local database.
    /// </summary>
    /// <param name="paymentId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Models.Payment> GetPaymentAsync(string paymentId)
    {
        try
        {
            return await _dbContext.Payments.FirstOrDefaultAsync(p => p.Id.ToString().Equals(paymentId));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get a list of payments done in a timespan
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Models.Payment>> GetPaymentsAsync(string startDate, string endDate)
    {
        try
        {
            var firstDate = DateTime.ParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
            var secondDate = DateTime.ParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
            return  _dbContext.Payments.Where(p => p.Created >= firstDate && p.Created <= secondDate).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// To be implemented by service Provider
    /// </summary>
    /// <param name="paymentId"></param>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> RefundPaymentAsync(string paymentId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// To be implemented by service provider
    /// </summary>
    /// <param name="paymentId"></param>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> CancelPaymentAsync(string paymentId)
    {
        throw new NotImplementedException();
    }
}