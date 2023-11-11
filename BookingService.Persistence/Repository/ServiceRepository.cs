using BookingService.Application.Contracts.Persistance;

namespace BookingService.Infrastructure.Persistence.Repository
{
    public class ServiceRepository : AsyncRepository<Domain.Entities.Service>, IServiceRepository
    {
        public ServiceRepository(BookingServiceContext bookingServiceContext) : base(bookingServiceContext)
        {
        }
    }
}
