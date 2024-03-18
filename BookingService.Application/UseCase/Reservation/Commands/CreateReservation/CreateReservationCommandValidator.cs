using FluentValidation;

namespace BookingService.Application.UseCase.Reservation.Commands.CreateReservation
{
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.ServiceId).NotNull().NotEmpty();
            RuleFor(x => x.StartDateAndTime).NotNull().NotEmpty();
            RuleFor(x => x.EndDateAndTime).NotNull().NotEmpty().GreaterThan(x => x.StartDateAndTime);
        }
    }
}
