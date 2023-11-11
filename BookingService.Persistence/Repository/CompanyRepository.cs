using BookingService.Application.Contracts.Persistance;

namespace BookingService.Infrastructure.Persistence.Repository
{
    public class CompanyRepository : AsyncRepository<Domain.Entities.Company>, ICompanyRepository
    {
        public CompanyRepository(BookingServiceContext bookingServiceContext) : base(bookingServiceContext) { }
    }
}
