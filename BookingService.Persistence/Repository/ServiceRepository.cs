using BookingService.Application.Contracts.Persistance;
using BookingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Persistence.Repository
{
    public class ServiceRepository : AsyncRepository<Domain.Entities.Service>, IServiceRepository
    {
        public ServiceRepository(BookingServiceContext bookingServiceContext) : base(bookingServiceContext)
        {
        }

        public async Task<List<Service>> GetAllWithChildren()
        {
            return await bookingServiceContext.Service.Where(x => x.Active).Include(x => x.Company).ToListAsync();
        }

        public async Task<Service?> GetServiceDetalis(int id)
        {
            return await bookingServiceContext.Service.Include(x => x.Company).ThenInclude(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Service>> GetServicesByCompanyId(int companyId)
        {
            return await bookingServiceContext.Service.Where(x => x.Company != null && x.Company.Id == companyId && x.Active).ToListAsync();
        }
    }
}
