using Airline.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Infrastructure.IServices.Services
{
    public class BookingRepository : IRepository<Booking>
    {
        private readonly AirlineDbContext _context;

        public BookingRepository(AirlineDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Booking>> GetAllAsync() => await _context.Bookings.ToListAsync();
        public async Task<Booking> GetByIdAsync(int id) => await _context.Bookings.FindAsync(id);

        public async Task  AddAsync(Booking entity) => await _context.Bookings.AddAsync(entity);
        public async Task DeleteAsync(Booking entity) => _context.Bookings.Remove(entity);

        public async Task UpdateAsync(Booking entity)
        {
            _context.Bookings.Where(b => b.Id == entity.Id)
                .ExecuteUpdate(b => b
                    .SetProperty(x => x.FlightId, entity.FlightId)
                    .SetProperty(x => x.PassengerName, entity.PassengerName)
                    .SetProperty(x => x.BookingDate, entity.BookingDate)
                    .SetProperty(x => x.IsCancelled, entity.IsCancelled));
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
