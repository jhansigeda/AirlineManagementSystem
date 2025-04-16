namespace AirlineManagementSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string PassengerName { get; set; }
        public DateTime BookingDate { get; set; }
        public string FlightNumber { get; set; }
    }
}
