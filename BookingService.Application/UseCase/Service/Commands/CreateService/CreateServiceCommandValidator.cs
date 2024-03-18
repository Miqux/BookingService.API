using FluentValidation;

namespace BookingService.Application.UseCase.Service.Commands.CreateService
{
    public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceCommandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(25);
            RuleFor(x => x.Cost).GreaterThan(0);
            RuleFor(x => x.DurationInMinutes).GreaterThan(0);
            RuleFor(x => x.CompanyId).GreaterThan(0);
        }
    }
}
