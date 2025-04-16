using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Airline.Application.IService;
using Airline.Application.Dto;

namespace Airline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookTicket([FromBody] BookingDTO dto)
        {
            await _bookingService.BookTicketAsync(dto);
            return Ok("Booking Successful");
        }

        [HttpPost("cancel/{id}")]
        public async Task<IActionResult> CancelTicket(int id)
        {
            await _bookingService.CancelBookingAsync(id);
            return Ok("Booking Cancelled Successfully");
        }

    }
}
