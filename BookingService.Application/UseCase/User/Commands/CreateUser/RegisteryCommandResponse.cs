using BookingService.Application.Common;

namespace BookingService.Application.UseCase.User.Commands.CreateUser
{
    public class RegisteryCommandResponse : BaseResponse
    {
        public int? UserId { get; set; }

        public RegisteryCommandResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public RegisteryCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public RegisteryCommandResponse(int userId)
        {
            UserId = userId;
        }
    }
}
