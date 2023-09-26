using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings
{
    public record GetBookingsWithinDataRangeQuery(DateOnly startTime, DateOnly endDate):IRequest<List<BookingsWithinDateRangeDto>>;    
}
