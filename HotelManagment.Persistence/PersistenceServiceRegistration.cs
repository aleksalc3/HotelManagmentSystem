using HotelManagment.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration) {
            services.AddDbContext<HotelDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HotelDatabaseConnectionString"));
            });
            return services; 
        }
    }
}
