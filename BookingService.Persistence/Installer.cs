using BookingService.Application.Contracts.Persistance;
using BookingService.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#nullable disable

namespace BookingService.Infrastructure.Persistence
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<ICalendarRepository, CalendarRepository>();

            return services;
        }
    }
}
