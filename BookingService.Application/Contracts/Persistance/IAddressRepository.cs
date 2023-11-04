using BookingService.Domain.Entities;

namespace BookingService.Application.Contracts.Persistance
{
    public interface IAddressRepository : IAsyncRepository<Address>
    {
    }
}
