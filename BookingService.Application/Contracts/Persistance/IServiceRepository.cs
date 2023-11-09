using BookingService.Domain.Entities;

namespace BookingService.Application.Contracts.Persistance
{
    public interface IServiceRepository : IAsyncRepository<Service>
    {
    }
}
