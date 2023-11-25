using MediatR;

namespace BookingService.Application.UseCase.Reservation.Commands
{
    public class CreatedReservationCommand : IRequest<CreatedReservationCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public DateTime StartDateAndTime { get; set; }
        public DateTime EndDateAndTime { get; set; }
    }
}
