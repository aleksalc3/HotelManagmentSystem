﻿using HotelManagmnet.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.User.Commands.CreateUser
{
    public class UpdateUserCommand :IRequest<Unit>
    {
        public int Id { get; set; }
        public string Password { get; set; } 

        public string Role { get; set; } 
    }
}
