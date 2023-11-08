using BookingService.Domain.Entities;

namespace BookingService.Application.Contracts.Persistance
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        public Task<User?> GetUserByNickAsync(string nick);
    }
}
