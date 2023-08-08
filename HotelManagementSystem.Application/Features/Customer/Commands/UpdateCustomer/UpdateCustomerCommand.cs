﻿using HotelManagmnet.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Customer.Commands.CreateCustomer
{
    public class UpdateCustomerCommand :IRequest<Unit>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
