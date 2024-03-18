namespace BookingService.Application.UseCase.Company.Commands.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(x => x.City).MinimumLength(3).MaximumLength(25);
            RuleFor(x => x.Street).MinimumLength(3).MaximumLength(25);
            RuleFor(x => x.CalendaryName).MinimumLength(3).MaximumLength(88);
            RuleFor(x => x.Zipcode).MinimumLength(6).MaximumLength(6);
            RuleFor(x => x.HouseNumber).GreaterThan(0);
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(0);
        }
    }
}
