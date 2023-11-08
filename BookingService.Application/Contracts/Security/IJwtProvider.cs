using BookingService.Domain.Entities;

namespace BookingService.Application.Contracts.Security
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
