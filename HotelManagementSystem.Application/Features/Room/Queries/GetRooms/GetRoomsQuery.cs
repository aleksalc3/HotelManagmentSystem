using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Room.Queries.GetAllRooms
{
    public record GetAllRoomsQuery:IRequest<List<RoomDto>>;    
}
