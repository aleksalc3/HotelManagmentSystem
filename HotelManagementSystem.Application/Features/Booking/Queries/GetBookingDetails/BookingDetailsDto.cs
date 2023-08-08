﻿using HotelManagementSystem.Application.Features.Customer.Queries.GetAllBookings;
using HotelManagementSystem.Application.Features.Room.Queries.GetAllRooms;
using HotelManagmnet.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings
{
    public class BookingDetailsDto
    {
        public int Id { get; set; }
        public CustomerDto Customer { get; set; }       
        public RoomDto Room { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
