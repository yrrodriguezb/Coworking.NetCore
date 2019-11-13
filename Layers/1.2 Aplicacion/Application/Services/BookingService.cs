using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DataAccess.Contracts.Repositories;
using Coworking.Api.Bussiness.Models;
using Coworking.Api.DataAccess;
using Coworking.Application.Contracts.Services;

namespace Coworking.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookinRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookinRepository = bookingRepository;
        }

        public async Task<Booking> GetBooking(int id)
        {
            var entity = await _bookinRepository.Get(id);
            return BookingMapper.Map(entity);
        }

        public async Task<Booking> AddBooking(Booking booking)
        {
            var addedEntity = await _bookinRepository.Add(BookingMapper.Map(booking));
            return BookingMapper.Map(addedEntity);
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            var bookings = await _bookinRepository.GetAll();
            return bookings.Select(BookingMapper.Map);
        }

        public Task DeleteBooking(int id)
        {
            return  _bookinRepository.DeleteAsync(id); 
        }

        public async Task<Booking> UpdateBooking(Booking booking)
        {
            var updated = await _bookinRepository.Update(BookingMapper.Map(booking));
            return BookingMapper.Map(updated);
        }
    }
}