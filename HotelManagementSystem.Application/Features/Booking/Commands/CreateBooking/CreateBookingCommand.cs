using HotelManagmnet.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Booking.Commands.CreateBooking
{
    public class CreateBookingCommand :IRequest<int>
    {
        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }
        public Room? Room { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
