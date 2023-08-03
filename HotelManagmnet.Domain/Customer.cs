using HotelManagmnet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmnet.Domain
{
    public class Customer : BaseEntity
    {

        public string Name { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Phone { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
    }
}
