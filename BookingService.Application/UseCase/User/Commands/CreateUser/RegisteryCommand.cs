namespace BookingService.Application.UseCase.User.Commands.CreateUser
{
    public class RegisteryCommand : IRequest<RegisteryCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }
}
