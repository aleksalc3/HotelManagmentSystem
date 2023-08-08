using HotelManagmnet.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Customer.Commands.CreateCustomer
{
    public class DeleteCustomerCommand :IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
