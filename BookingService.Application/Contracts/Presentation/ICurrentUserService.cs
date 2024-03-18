namespace BookingService.Application.Contracts.Presentation
{
    public interface ICurrentUserService
    {
        public int? UserId { get; }
        public string? UserRole { get; }
    }
}
