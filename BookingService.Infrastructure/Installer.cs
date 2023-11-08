using BookingService.Application.Contracts.Security;
using BookingService.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.Infrastructure
{
    public static class Installer
    {
        public static IServiceCollection AddBookingServicePersistence(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHashService, PasswordHashService>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            return services;
        }
    }
}
