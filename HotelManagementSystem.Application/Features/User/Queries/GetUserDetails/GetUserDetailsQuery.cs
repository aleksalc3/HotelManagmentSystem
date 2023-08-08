using HotelManagementSystem.Application.Features.User.Queries.GetAllUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.User.Queries.GetUserDetails
{
    public record GetUserDetailsQuery(int Id):IRequest<UserDetailsDto>;
    
}
