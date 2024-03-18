namespace BookingService.Application.UseCase.Reservation.Commands.DeleteReservation
{
    public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
    {
        public DeleteReservationCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
        }
    }
}
