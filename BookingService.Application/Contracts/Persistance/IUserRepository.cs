namespace BookingService.Application.Contracts.Persistance
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        public Task<User?> GetUserByLoginAsync(string login);
        public Task<User?> GetUserByEmailAsync(string email);
    }
}
