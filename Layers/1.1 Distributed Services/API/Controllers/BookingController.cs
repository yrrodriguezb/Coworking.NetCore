using System.Collections.Generic;
using System.Threading.Tasks;
using Coworking.API.Mappers;
using Coworking.API.ViewModels;
using Coworking.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Coworking.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        /// <summary>
        /// GET all Booking
        /// </summary>
        /// <returns>Booking Collection</returns>
        [HttpGet]
        [Produces("application/json", Type = typeof(List<BookingModel>))]
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _bookingService.GetAllBookings();
            return Ok(bookings);
        }

        /// <summary>
        /// GET a Booking
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Booking</returns>
        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(BookingModel))]
        public async Task<IActionResult> Get(int id)
        {
            var booking = await _bookingService.GetBooking(id);
            return Ok(booking);
        }

        /// <summary>
        /// Add a new booking
        /// </summary>
        /// <param name="boking"></param>
        /// <returns>Booking</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [Produces("application/json", Type = typeof(BookingModel))]
        [HttpPost]
        public async Task<IActionResult> AddBooking([FromBody] BookingModel booking)
        {
            var newBooking = await _bookingService.AddBooking(BookingMapper.Map(booking));
            return Ok(newBooking);
        }

        /// <summary>
        /// Delete a booking
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpDelete("{id}")]
        [Produces("application/json", Type = typeof(bool))]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingService.DeleteBooking(id);
            return Ok();
        }

        /// <summary>
        /// Update a booking
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>Booking</returns>
        [HttpPut]
        [Produces("application/json", Type = typeof(BookingModel))]
        public async Task<IActionResult> UpdateBooking([FromBody]BookingModel booking)
        {
            var updatedBooking = await _bookingService.UpdateBooking(BookingMapper.Map(booking));
            return Ok(updatedBooking);
        }

    }
}