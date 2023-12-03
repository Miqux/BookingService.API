using BookingService.Application.Contracts.Calendary;
using BookingService.Infrastructure.GoogleCalendar.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.Infrastructure.GoogleCalendar
{
    public static class Installer
    {
        public static IServiceCollection AddBookingServiceGoogleCalendar(this IServiceCollection services)
        {
            services.AddScoped<IGoogleCalendaryRepository, GoogleCalendaryRepository>();

            return services;
        }
    }
}
