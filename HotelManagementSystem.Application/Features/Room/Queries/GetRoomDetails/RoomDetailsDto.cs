using HotelManagmnet.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Room.Queries.GetAllRooms
{
    public class RoomDetailsDto
    {
        public int Id { get; set; }
        public string RoomType { get; set; } 

        public int RoomNumber { get; set; }

        public int Capacity { get; set; }

        public bool IsAvailable { get; set; }
    }
}
