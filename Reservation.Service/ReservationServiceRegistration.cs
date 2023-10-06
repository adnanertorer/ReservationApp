﻿using IsSystem.Application.Rules;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Reservation.Service
{
    public static class ReservationServiceRegistration
    {
        public static IServiceCollection AddReservationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), type: typeof(BaseBusinessRule));
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });
            return services;
        }

        public static IServiceCollection AddSubClassesOfType(this IServiceCollection services, Assembly assembly, Type type,
     Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                if (addWithLifeCycle == null)
                    services.AddScoped(item);
                else
                    addWithLifeCycle(services, type);
            return services;
        }
    }
}
