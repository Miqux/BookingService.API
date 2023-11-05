using BookingService.Application.Contracts.Persistance;
using BookingService.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#nullable disable

namespace BookingService.Persistence
{
    public static class Installer
    {
        public static IServiceCollection AddBookingServicePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookingServiceContext>(options =>
                options.UseSqlServer(configuration.
                GetConnectionString("BookingServiceConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));

            services.AddScoped<IAddressRepository, AddressRepository>();

            return services;
        }
    }
}
