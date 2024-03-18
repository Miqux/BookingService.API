using FluentValidation;

namespace BookingService.Application.UseCase.Address.Commands.CreateAddress
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(x => x.City).MinimumLength(3).MaximumLength(25);
            RuleFor(x => x.Street).MinimumLength(3).MaximumLength(25);
            RuleFor(x => x.Zipcode).MinimumLength(6).MaximumLength(6);
            RuleFor(x => x.HouseNumber).GreaterThan(0);
        }
    }
}
