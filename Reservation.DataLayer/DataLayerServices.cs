using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Reservation.DataLayer
{
    public static class DataLayerServices
    {
        public static IServiceCollection AddDataLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReservationDbContext>(builder => builder.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"), b =>
            b.MigrationsAssembly("ReservationAPI")));
            return services;
        }
    }
}
