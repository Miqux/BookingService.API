using BookingService.Application.Common;

namespace BookingService.Application.UseCase.Reservation.Commands.CreateReservation
{
    public class CreateReservationCommandResponse : BaseResponse
    {
        public int? ReservationId { get; set; }
        public CreateReservationCommandResponse(ValidationResult validationResult)
             : base(validationResult)
        { }

        public CreateReservationCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public CreateReservationCommandResponse(int reservationId)
        {
            ReservationId = reservationId;
        }
    }
}
