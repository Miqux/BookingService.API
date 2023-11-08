using BookingService.Application.Contracts.Persistance;
using BookingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Persistence.Repository
{
    public class UserRepository : AsyncRepository<User>, IUserRepository
    {
        public UserRepository(BookingServiceContext bookingServiceContext) : base(bookingServiceContext) { }

        public async Task<User?> GetUserByNickAsync(string nick)
        {
            return await bookingServiceContext.User.FirstOrDefaultAsync(x => x.Nick == nick);
        }
    }
}
