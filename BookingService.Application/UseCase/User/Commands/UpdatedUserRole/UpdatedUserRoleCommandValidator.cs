using FluentValidation;

namespace BookingService.Application.UseCase.User.Commands.UpdatedUserRole
{
    public class UpdatedUserRoleCommandValidator : AbstractValidator<UpdatedUserRoleCommand>
    {
        public UpdatedUserRoleCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.Role).NotNull();
        }
    }
}
