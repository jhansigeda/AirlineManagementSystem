using Microsoft.AspNetCore.Mvc;

namespace AirlineManagementSystem.Controllers
{
    public class FlightController : Controller
    {
        private readonly HttpClient _httpClient;

        public FlightController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

     
        public async Task<IActionResult> Index()
        {
            var flight = await _httpClient.GetAsync("https://localhost:7043/api/Flight/GetFlights");//https://localhost:5001/api/Flight
            return View();
        }
    }
}
