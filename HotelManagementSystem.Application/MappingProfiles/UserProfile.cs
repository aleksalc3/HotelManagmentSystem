using AutoMapper;
using HotelManagementSystem.Application.Features.Booking.Commands.CreateBooking;
using HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings;
using HotelManagementSystem.Application.Features.User.Commands.CreateUser;
using HotelManagementSystem.Application.Features.User.Queries.GetAllUsers;
using HotelManagmnet.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<User, UserDetailsDto>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();

        }
    }
}
