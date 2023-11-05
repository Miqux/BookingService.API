using BookingService.Application.Contracts.Persistance;
using BookingService.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.Persistence
{
    public static class Installer
    {
        public static IServiceCollection AddBookingServicePersistence(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));

            services.AddScoped<IAddressRepository, AddressRepository>();

            return services;
        }
    }
}
