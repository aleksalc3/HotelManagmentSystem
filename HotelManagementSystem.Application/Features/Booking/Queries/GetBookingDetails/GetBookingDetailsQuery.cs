using HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Booking.Queries.GetBookingDetails
{
    public record GetBookingDetailsQuery(int Id):IRequest<BookingDetailsDto>;
    
}
