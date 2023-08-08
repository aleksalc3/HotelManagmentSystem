using AutoMapper;
using HotelManagementSystem.Application.Features.Booking.Commands.CreateBooking;
using HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings;
using HotelManagementSystem.Application.Features.Room.Commands.CreateRoom;
using HotelManagementSystem.Application.Features.Room.Queries.GetAllRooms;
using HotelManagmnet.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.MappingProfiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomDto, Room>().ReverseMap();
            CreateMap<Room, RoomDetailsDto>();
            CreateMap<CreateRoomCommand, Room>();
            CreateMap<UpdateRoomCommand, Room>();

        }
    }
}
