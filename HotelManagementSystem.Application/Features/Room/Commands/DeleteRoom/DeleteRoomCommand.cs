using HotelManagmnet.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Room.Commands.CreateRoom
{
    public class DeleteRoomCommand :IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
