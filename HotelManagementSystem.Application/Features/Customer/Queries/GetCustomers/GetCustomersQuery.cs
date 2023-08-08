using HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings;
using HotelManagementSystem.Application.Features.Customer.Queries.GetAllBookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Customer.Queries.GetAllCustomers
{
    public record GetCustomersQuery:IRequest<List<CustomerDto>>;    
}
