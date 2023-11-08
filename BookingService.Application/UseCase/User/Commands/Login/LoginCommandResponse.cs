using BookingService.Application.Common;

namespace BookingService.Application.UseCase.User.Commands.Login
{
    public class LoginCommandResponse : BaseResponse
    {
        public string Token { get; set; } = string.Empty;
        public LoginCommandResponse(string message, bool success)
            : base(message, success)
        { }
        public LoginCommandResponse(string token) : base()
        {
            Token = token;
        }
    }
}
