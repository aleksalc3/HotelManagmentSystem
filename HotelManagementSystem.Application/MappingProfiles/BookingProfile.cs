using AutoMapper;
using HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings;
using HotelManagmnet.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.MappingProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingsDto, Booking>().ReverseMap();
            CreateMap<Booking, BookingDetailsDto>();
        }
    }
}
