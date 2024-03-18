using FluentValidation;

namespace BookingService.Application.UseCase.Post.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(x => x.Title).MinimumLength(3).MaximumLength(25);
            RuleFor(x => x.Content).MinimumLength(3).MaximumLength(1000);
        }
    }
}
