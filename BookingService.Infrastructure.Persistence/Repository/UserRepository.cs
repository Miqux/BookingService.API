using BookingService.Application.Contracts.Persistance;
using BookingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Persistence.Repository
{
    public class UserRepository : AsyncRepository<User>, IUserRepository
    {
        public UserRepository(BookingServiceContext bookingServiceContext) : base(bookingServiceContext) { }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await bookingServiceContext.User.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetUserByLoginAsync(string login)
        {
            return await bookingServiceContext.User.FirstOrDefaultAsync(x => x.Login == login);
        }
    }
}
