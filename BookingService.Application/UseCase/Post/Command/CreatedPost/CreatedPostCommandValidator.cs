using FluentValidation;

namespace BookingService.Application.UseCase.Post.Command.CreatedPost
{
    public class CreatedPostCommandValidator : AbstractValidator<CreatedPostCommand>
    {
        public CreatedPostCommandValidator()
        {
            RuleFor(x => x.Title).MinimumLength(3).MaximumLength(25);
            RuleFor(x => x.Content).MinimumLength(3).MaximumLength(1000);
        }
    }
}
