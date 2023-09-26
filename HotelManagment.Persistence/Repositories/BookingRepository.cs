using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagment.Persistence.DatabaseContext;
using HotelManagmnet.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Persistence.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(HotelDatabaseContext context) : base(context)
        {

        }
        public async Task<Booking> GetBookingWithRoomAndCustomer(int bookingId)
        {
            var booking = await _context.Bookings.Include(b => b.Room)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(b => b.Id == bookingId);
            return booking;
        }
        public async Task<bool> CancelBooking(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null) return false;

            var room = await _context.Rooms.FindAsync(booking.RoomId);
            if (room != null) room.IsAvailable = true;

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Booking>> GetBookingsByDate(DateTime date)
        {
            return await _context.Bookings
                .Where(q => q.StartDate.Date <= date && q.EndDate.Date >= date)
                .ToListAsync();
        }

        public async Task<decimal> GetBookingTotalAmount(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null) return 0;

            var numberOfNights = (int)(booking.EndDate - booking.StartDate).TotalDays;
            const decimal roomRatePerNight = 100;

            return numberOfNights * roomRatePerNight;
        }

        public async Task<List<Booking>> GetPastReservations()
        {
            var currentDate = DateTime.Today;
            return await _context.Bookings
                .Where(q => q.EndDate < currentDate)
                .ToListAsync();
        }

        public async Task<List<Booking>> GetUpcomingBookings()
        {
            var currentDate = DateTime.Today;
            return await _context.Bookings
                .Where(q => q.StartDate > currentDate)
                .ToListAsync();
        }

        public async Task<List<Booking>> GetBookingsWithinDateRange(DateOnly startDate, DateOnly endDate)
        {

            var startDateParam = new SqlParameter("@StartDate", SqlDbType.Date)
            {
                Value = startDate,
            };

            var endDateParam = new SqlParameter("@EndDate", SqlDbType.Date)
            {
                Value = endDate,
            };
            var result = await _context.Database.ExecuteSqlRawAsync(
                "EXEC GetBookingsWithinDateRange @StartDate, @EndDate",
                startDateParam, endDateParam);

            // Now manually load related entities (Customer and Room) and map to Booking entities
            var bookings = _context.Bookings                
                .Include(b => b.Customer)
                .Include(b => b.Room)
                .ToList();

            return bookings;
        }
    }
}
