namespace BookingService.Application.UseCase.User.Commands.CreateUser
{
    public class RegisteryCommandValidator : AbstractValidator<RegisteryCommand>
    {
        public RegisteryCommandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.LastName).MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.Login).MinimumLength(5).MaximumLength(20);
            RuleFor(x => x.Password).MinimumLength(5).MaximumLength(20);
            RuleFor(x => x.Role).NotNull();
            RuleFor(x => x.Email).NotNull().EmailAddress();
        }
    }
}
