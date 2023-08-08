using HotelManagmnet.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.User.Queries.GetAllUsers
{
    public class UserDetailsDto
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
