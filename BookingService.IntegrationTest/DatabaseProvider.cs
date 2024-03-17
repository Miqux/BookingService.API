using BookingService.Application.Contracts.Presentation;
using BookingService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
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

            var mockCurrentUserService = new Mock<ICurrentUserService>();
            mockCurrentUserService.Setup(repo => repo.UserRole).Returns("IntegrationTest");
            mockCurrentUserService.Setup(repo => repo.UserId).Returns(29);

            return new BookingServiceContext(optionsBuilder.Options, mockCurrentUserService.Object);
        }
    }
}
