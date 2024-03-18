namespace BookingService.Application.Contracts.Security
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
