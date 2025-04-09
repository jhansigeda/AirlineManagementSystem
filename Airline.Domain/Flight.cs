namespace Airline.Domain
{
    public abstract class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Duration { get; set; }
        public double Speed { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
    }

    public class DomesticFlight : Flight { }

    public class InternationalFlight : Flight
    {
        public bool IsPassportRequired { get; set; }
        public bool IsVisaApproved { get; set; }
    }

    public class CharterFlight : Flight
    {
        public string CharteredCompany { get; set; }
        public string CaptainName { get; set; }
        public int Capacity { get; set; }
    }

}
