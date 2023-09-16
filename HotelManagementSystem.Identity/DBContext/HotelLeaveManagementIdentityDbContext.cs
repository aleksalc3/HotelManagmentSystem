using HotelManagementSystem.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Identity.DbContext
{
    public class HotelManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public HotelManagementIdentityDbContext(DbContextOptions<HotelManagementIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(HotelManagementIdentityDbContext).Assembly);
        }
    }
}
