namespace BookingService.Application.UseCase.Reservation.Commands.CreateReservation
{
    public class CreateReservationCommand : IRequest<CreateReservationCommandResponse>
    {
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public DateTime StartDateAndTime { get; set; }
        public DateTime EndDateAndTime { get; set; }
    }
}
