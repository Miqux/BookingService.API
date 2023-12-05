using FluentValidation;

namespace BookingService.Application.UseCase.Reservation.Commands.AddReservation
{
    public class CreatedReservationCommandValidator : AbstractValidator<CreatedReservationCommand>
    {
        public CreatedReservationCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.ServiceId).NotNull().NotEmpty();
            RuleFor(x => x.StartDateAndTime).NotNull().NotEmpty();
            RuleFor(x => x.EndDateAndTime).NotNull().NotEmpty().GreaterThan(x => x.StartDateAndTime);
        }
    }
}
