using Airline.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.IService
{
    public interface IBookingService
    {
        Task BookTicketAsync(BookingDTO bookingDto);
        Task CancelBookingAsync(int bookingId);
    }
}
