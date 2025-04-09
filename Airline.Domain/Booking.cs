using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string PassengerName { get; set; }
        public DateTime BookingDate { get; set; }
        public bool IsCancelled { get; set; }
    }
}
