using AirlineManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineManagementSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly HttpClient _httpClient;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost]
        public async Task<IActionResult> Book(Booking booking)
        {
            booking.BookingDate = DateTime.Now;
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7043/api/booking", booking);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Booking successful!";
            }
            else
            {
                TempData["Message"] = "Booking failed!";
            }

            return RedirectToAction("Index", "Flight");
        }

        public async Task<IActionResult> MyBookings()
        {
            var bookings = await _httpClient.GetFromJsonAsync<List<Booking>>("https://localhost:7043/api/booking");
            return View(bookings);
        }
    }
}
