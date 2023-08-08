using HotelManagmnet.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Room.Commands.CreateRoom
{
    public class CreateRoomCommand :IRequest<int>
    {
        public string RoomType { get; set; }

        public int RoomNumber { get; set; }

        public int Capacity { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
