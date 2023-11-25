using BookingService.Application.Common;

namespace BookingService.Application.UseCase.Reservation.Commands
{
    public class CreatedReservationCommandResponse : BaseResponse
    {
        public int? ReservationId { get; set; }
        public CreatedReservationCommandResponse() : base()
        { }

        public CreatedReservationCommandResponse(string message)
        : base(message)
        { }

        public CreatedReservationCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public CreatedReservationCommandResponse(int reservationId)
        {
            ReservationId = reservationId;
        }
    }
}
