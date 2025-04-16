using Airline.Application.Dto;
using Airline.Application.IService.Service;
using Airline.Domain;
using Airline.Infrastructure.IServices;
using Moq;

namespace Airline.Tests
{
    [TestClass]
    public sealed class BookingServiceTests
    {

        private BookingService _bookingService;
        private Mock<IRepository<Booking>> _mockRepo;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<IRepository<Booking>>();
            _bookingService = new BookingService(_mockRepo.Object);
        }

        [TestMethod]
        public async Task BookTicketAsync_ShouldCallAddAndSave()
        {
            var bookingDto = new BookingDTO { FlightId = 1, PassengerName = "John Doe" };
            await _bookingService.BookTicketAsync(bookingDto);

            _mockRepo.Verify(r => r.AddAsync(It.IsAny<Booking>()), Times.Once);
            _mockRepo.Verify(r => r.SaveAsync(), Times.Once);
        }

        [TestMethod]
        public async Task CancelBookingAsync_ShouldSetIsCancelledTrue()
        {
            var booking = new Booking { Id = 1, IsCancelled = false };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(booking);

            await _bookingService.CancelBookingAsync(1);

            Assert.IsTrue(booking.IsCancelled);
            _mockRepo.Verify(r => r.UpdateAsync(booking), Times.Once);
            _mockRepo.Verify(r => r.SaveAsync(), Times.Once);
        }
    }
}
