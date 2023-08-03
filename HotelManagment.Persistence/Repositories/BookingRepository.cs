using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagment.Persistence.DatabaseContext;
using HotelManagmnet.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
