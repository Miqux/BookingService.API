using BookingService.Application.Contracts.Persistance;
using BookingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Persistence.Repository
{
    public class CompanyRepository : AsyncRepository<Domain.Entities.Company>, ICompanyRepository
    {
        public CompanyRepository(BookingServiceContext bookingServiceContext) : base(bookingServiceContext) { }

        public async Task<Company?> GetByName(string name)
        {
            return await bookingServiceContext.Company.FirstOrDefaultAsync(x => x.Name.Equals(name));
        }

        public async Task<Company?> GetByUserId(int userId)
        {
            return await bookingServiceContext.Company.FirstOrDefaultAsync(x => x.CompanyBoss.Id == userId);
        }

    }
}
