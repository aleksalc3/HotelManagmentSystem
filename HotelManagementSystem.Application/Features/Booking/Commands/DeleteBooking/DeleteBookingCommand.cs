using HotelManagmnet.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Booking.Commands.CreateBooking
{
    public class DeleteBookingCommand :IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
