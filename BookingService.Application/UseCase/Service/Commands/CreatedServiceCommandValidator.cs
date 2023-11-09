using FluentValidation;

namespace BookingService.Application.UseCase.Service.Commands
{
    public class CreatedServiceCommandValidator : AbstractValidator<CreatedServiceCommand>
    {
        public CreatedServiceCommandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(25);
            RuleFor(x => x.Cost).GreaterThan(0);
            RuleFor(x => x.DurationInMinutes).GreaterThan(0);
            RuleFor(x => x.ComapnyId).GreaterThan(0);
            RuleFor(x => x.EmployeeId).GreaterThan(0);
        }
    }
}
