using HotelManagmnet.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings
{
    public class BookingDetailsDto
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public Room? Room { get; set; }
        public int RoomId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
