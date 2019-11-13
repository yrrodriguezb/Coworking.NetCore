using System.Collections.Generic;
using System.Threading.Tasks;
using Coworking.Api.Bussiness.Models;

namespace Coworking.Application.Contracts.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookings();
        Task<Booking> GetBooking(int id);
        Task<Booking> AddBooking(Booking booking);
        Task DeleteBooking(int id);
        Task<Booking> UpdateBooking(Booking booking);
    }
}