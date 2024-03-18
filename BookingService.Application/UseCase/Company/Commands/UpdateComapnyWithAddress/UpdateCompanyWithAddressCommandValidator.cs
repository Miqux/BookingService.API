using FluentValidation;

namespace BookingService.Application.UseCase.Company.Commands.UpdateComapnyWithAddress
{
    public class UpdateCompanyWithAddressCommandValidator : AbstractValidator<UpdateCompanyWithAddressCommand>
    {
        public UpdateCompanyWithAddressCommandValidator()
        {
            RuleFor(x => x.CompanyName).MinimumLength(3).MaximumLength(25);
            RuleFor(x => x.City).MinimumLength(3).MaximumLength(25);
            RuleFor(x => x.Street).MinimumLength(3).MaximumLength(25);
            RuleFor(x => x.Zipcode).Length(6);
            RuleFor(x => x.HouseNumber).NotNull().GreaterThan(0);
            RuleFor(x => x.CompanyId).NotNull().GreaterThan(0);
        }
    }
}

