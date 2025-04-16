using Airline.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Infrastructure.IServices.Services
{
    public class FlightRepository: IRepository<Flight>
    {
        private readonly AirlineDbContext _context;

        public FlightRepository(AirlineDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Flight>> GetAllAsync() => await _context.Flights.ToListAsync();
        public async Task<Flight> GetByIdAsync(int id) => await _context.Flights.FindAsync(id);
        public async Task AddAsync(Flight entity) => await _context.Flights.AddAsync(entity);
        public async Task DeleteAsync(Flight entity) => _context.Flights.Remove(entity);
        //public async Task UpdateAsync(Flight entity) => await _context.Flights.ExecuteUpdateAsync(entity);
        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public async Task UpdateAsync(Flight entity)
        {
            _context.Flights.Update(entity); // Corrected to use the Update method
            await _context.SaveChangesAsync(); // Ensure changes are saved
        }

        //public async Task<IEnumerable<Flight>> GetAllAsync() => await _context.Flights.ToListAsync();

        //public async Task<Flight> GetByIdAsync(int id) => await _context.Flights.FindAsync(id);

        //public async Task<Flight> AddAsync(Flight flight)
        //{
        //    _context.Flights.Add(flight);
        //    await _context.SaveChangesAsync();
        //    return flight;
        //}

        //public async Task<Flight> UpdateAsync(Flight flight)
        //{
        //    _context.Flights.Update(flight);
        //    await _context.SaveChangesAsync();
        //    return flight;
        //}

        //public async Task<bool> DeleteAsync(int id)
        //{
        //    var flight = await _context.Flights.FindAsync(id);
        //    if (flight == null) return false;
        //    _context.Flights.Remove(flight);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}
    }
}
