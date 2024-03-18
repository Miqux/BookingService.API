using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookingService.Application
{
    public static class Installer
    {
        public static IServiceCollection AddBookingServiceApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
