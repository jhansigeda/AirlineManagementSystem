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

        public async Task AddAsync(Booking entity) => await _context.Bookings.AddAsync(entity);
        public void Delete(Booking entity) => _context.Bookings.Remove(entity);
        public async Task<IEnumerable<Booking>> GetAllAsync() => await _context.Bookings.ToListAsync();
        public async Task<Booking> GetByIdAsync(int id) => await _context.Bookings.FindAsync(id);
        public void Update(Booking entity) => _context.Bookings.Update(entity);
        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
