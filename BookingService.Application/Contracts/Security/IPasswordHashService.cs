namespace BookingService.Application.Contracts.Security
{
    public interface IPasswordHashService
    {
        public string Encrypt(string password);
        public bool ComparePassword(string password, string passwordHash);
    }
}
