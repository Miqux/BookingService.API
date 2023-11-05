using BookingService.Application.Contracts.Persistance;
using BookingService.Domain.Entities;

namespace BookingService.Persistence.Repository
{
    public class AddressRepository : AsyncRepository<Address>, IAddressRepository
    {
        private StaticContext context { get; set; }
        public AddressRepository()
        {
            context = new StaticContext();
        }
        public async override Task<Address> AddAsync(Address entity)
        {
            await Task.Run(() => context.Address.Add(entity));
            return entity;
        }
        public async override Task<Address> GetByIdAsync(int id)
        {
            Address? entity = new();
            await Task.Run(() => entity = context.Address.Find(x => x.Id == id));
            return entity != null ? entity : new Address();
        }
    }
}
