using HotelManagmnet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Persistence.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasData(
                new Booking
                {
                    Id = 1,
                    Customer = null,
                    Room = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(10),
                }
            );

            //database restriction example
            builder.Property(q => q.StartDate)
                .IsRequired();
        }
    }
}
