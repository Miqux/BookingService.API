using BookingService.Application.Contracts.Persistance;

namespace BookingService.Infrastructure.Persistence.Repository
{
    public class EmployeeRepository : AsyncRepository<Domain.Entities.Employee>, IEmployeeRepository
    {
        public EmployeeRepository(BookingServiceContext bookingServiceContext) : base(bookingServiceContext)
        {
        }
    }
}
