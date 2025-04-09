using Airline.Application.Dto;
using Airline.Domain;
using Airline.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.IService.Service
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _bookingRepo;

        public BookingService(IRepository<Booking> bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public async Task BookTicketAsync(BookingDTO bookingDto)
        {
            var booking = new Booking
            {
                FlightId = bookingDto.FlightId,
                PassengerName = bookingDto.PassengerName,
                BookingDate = DateTime.UtcNow,
                IsCancelled = false
            };
            await _bookingRepo.AddAsync(booking);
            await _bookingRepo.SaveAsync();
        }

        public async Task CancelBookingAsync(int bookingId)
        {
            var booking = await _bookingRepo.GetByIdAsync(bookingId);
            if (booking == null) throw new Exception("Booking not found");
            booking.IsCancelled = true;
            _bookingRepo.Update(booking);
            await _bookingRepo.SaveAsync();
        }
    }
}
