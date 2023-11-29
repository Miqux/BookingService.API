using FluentValidation;

namespace BookingService.Application.UseCase.Service.Commands.AddService
{
    public class CreatedServiceCommandValidator : AbstractValidator<CreatedServiceCommand>
    {
        public CreatedServiceCommandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(25);
            RuleFor(x => x.Cost).GreaterThan(0);
            RuleFor(x => x.DurationInMinutes).GreaterThan(0);
            RuleFor(x => x.CompanyId).GreaterThan(0);
        }
    }
}
