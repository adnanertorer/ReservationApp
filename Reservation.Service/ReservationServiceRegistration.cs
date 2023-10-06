using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Reservation.Service
{
    public static class ReservationServiceRegistration
    {
        public static IServiceCollection AddReservationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });
            return services;
        }
    }
}
