using HotelManagmnet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmnet.Domain
{
    public class Room : BaseEntity
    {
        
        public string RoomType { get; set; } = String.Empty;

        public int RoomNumber { get; set; }

        public int Capacity { get; set; }

        public bool IsAvailable { get; set; }

    }
}
