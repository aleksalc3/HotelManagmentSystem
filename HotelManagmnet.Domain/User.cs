using HotelManagmnet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmnet.Domain
{
    public class User : BaseEntity
    {
        
        

        public string Username { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;

        public string Role { get; set; } = String.Empty;
    }
}
