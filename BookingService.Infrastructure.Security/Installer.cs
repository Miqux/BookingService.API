using BookingService.Application.Contracts.Security;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.Infrastructure.Security
{
    public static class Installer
    {
        public static IServiceCollection AddBookingServiceSecurity(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHashService, PasswordHashService>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            return services;
        }
    }
}
