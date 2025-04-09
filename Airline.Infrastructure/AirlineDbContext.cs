using Airline.Domain;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure
{
    public class AirlineDbContext : DbContext
    {
        public AirlineDbContext(DbContextOptions<AirlineDbContext> options) : base(options) { }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasDiscriminator<string>("FlightType")
                .HasValue<DomesticFlight>("Domestic")
                .HasValue<InternationalFlight>("International")
                .HasValue<CharterFlight>("Charter");
        }

    }
}
