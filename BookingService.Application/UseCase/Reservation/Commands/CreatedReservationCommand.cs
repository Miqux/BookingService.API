using MediatR;

namespace BookingService.Application.UseCase.Reservation.Commands
{
    public class CreatedReservationCommand : IRequest<CreatedReservationCommandResponse>
    {
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public DateTime StartDateAndTime { get; set; }
        public DateTime EndDateAndTime { get; set; }
    }
}
