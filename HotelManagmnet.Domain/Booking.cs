using HotelManagmnet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmnet.Domain
{
    public class Booking:BaseEntity
    {
        public User? User { get; set; }
        public int UserId { get; set; }
        public Room? Room { get; set; }
        public int RoomId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
