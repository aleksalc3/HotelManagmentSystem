using HotelManagementSystem.Application.Features.Customer.Queries.GetAllBookings;
using HotelManagementSystem.Application.Features.Room.Queries.GetAllRooms;
using HotelManagmnet.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings
{
    public class BookingsWithinDateRangeDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
