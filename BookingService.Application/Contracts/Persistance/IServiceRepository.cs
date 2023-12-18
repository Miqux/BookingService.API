using BookingService.Domain.Entities;
using static BookingService.Domain.Entities.Enums;

namespace BookingService.Application.Contracts.Persistance
{
    public interface IServiceRepository : IAsyncRepository<Service>
    {
        public Task<List<Service>> GetServicesByCompanyId(int companyId);
        public Task<List<Service>> GetAllWithChildren(ServiceType? serviceType = null, string? city = null);
        public Task<Service?> GetWithChildren(int id, bool withComapnyCalendar = false);
        public Task<Service?> GetServiceDetalis(int id);
    }
}
