using HotelManagementSystem.Application.Features.Room.Queries.GetAllRooms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Room.Queries.GetRoomDetails
{
    public record GetRoomDetailsQuery(int Id):IRequest<RoomDetailsDto>;
    
}
