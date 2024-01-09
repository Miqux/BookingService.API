using BookingService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
#nullable disable
namespace BookingService.IntegrationTest
{
    public static class DatabaseProvider
    {
        public static BookingServiceContext GetApplicationContext()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<BookingServiceContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BookingServiceConnectionString"));
            return new BookingServiceContext(optionsBuilder.Options);
        }
    }
}
