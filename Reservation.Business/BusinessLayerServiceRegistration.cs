using Microsoft.Extensions.DependencyInjection;
using Reservation.Business.Repositories.Abstracts;
using Reservation.Business.Repositories.Concrete;

namespace Reservation.Business
{
    public static class BusinessLayerServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<ICustomerReservationRepository, CustomerReservationRepository>();
            return services;
        }
    }
}
