using HotelManagmnet.Domain;

namespace HotelManagementSystem.Application.Contracts.Persistence
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<List<Booking>> GetBookingsByDate(DateTime date);
        Task<List<Booking>> GetUpcomingBookings();
        Task<List<Booking>> GetPastReservations();
        Task<Booking> GetBookingWithRoomAndCustomer(int bookingId);
        Task<decimal> GetBookingTotalAmount(int bookingId);
        Task<bool> CancelBooking(int bookingId);
    }
}
