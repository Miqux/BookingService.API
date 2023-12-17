using FluentValidation;

namespace BookingService.Application.UseCase.Reservation.Commands.DeletedReservation
{
    public class DeletedReservationCommandValidator : AbstractValidator<DeletedReservationCommand>
    {
        public DeletedReservationCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
        }
    }
}
