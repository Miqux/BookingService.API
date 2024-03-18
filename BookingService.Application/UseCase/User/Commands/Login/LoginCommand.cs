namespace BookingService.Application.UseCase.User.Commands.Login
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
