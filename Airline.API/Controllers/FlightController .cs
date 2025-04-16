using Airline.Domain;
using Airline.Infrastructure.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IRepository<Flight> _repository;

        public FlightController(IRepository<Flight> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetFlights")]
        public async Task<IActionResult> GetAllFlights()
        {
            var flights = await _repository.GetAllAsync();
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlight(int id)
        {
            var flight = await _repository.GetByIdAsync(id);
            return flight == null ? NotFound() : Ok(flight);
        }


        [HttpPost]
        [Route("AddFlight")]
        public async Task<IActionResult> CreateFlight([FromBody]Flight flight)
        {
            await _repository.AddAsync(flight); // AddAsync returns void, so no assignment is needed
            return CreatedAtAction(nameof(GetFlight), new { id = flight.Id }, flight);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateFlight([FromBody] Flight flight)
        //{
        //    await _repository.AddAsync(flight);
        //    return CreatedAtAction(nameof(GetFlight), new { id = createdFlight.Id }, createdFlight);
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] Flight flight)
        {
            if (id != flight.Id) return BadRequest("ID mismatch");
            await _repository.UpdateAsync(flight);
            return Ok(flight);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flight = await _repository.GetByIdAsync(id);
            if (flight == null) return NotFound();
            await _repository.DeleteAsync(flight);
            return NoContent();
        }
    }
}
