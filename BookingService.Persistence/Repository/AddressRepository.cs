using BookingService.Application.Contracts.Persistance;
using BookingService.Domain.Entities;

namespace BookingService.Persistence.Repository
{
    public class AddressRepository : AsyncRepository<Address>, IAddressRepository
    {
        public AddressRepository(BookingServiceContext bookingServiceContext) : base(bookingServiceContext) { }
    }
}
