using BookingService.Application.Contracts.Security;

namespace BookingService.Infrastructure.Security
{
    public class PasswordHashService : IPasswordHashService
    {
        public bool ComparePassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
        }

        public string Encrypt(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
            return passwordHash;
        }
    }
}
