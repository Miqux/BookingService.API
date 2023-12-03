using BookingService.Application.Common;
using FluentValidation.Results;

namespace BookingService.Application.UseCase.Reservation.Commands
{
    public class CreatedReservationCommandResponse : BaseResponse
    {
        public int? ReservationId { get; set; }
        public CreatedReservationCommandResponse(ValidationResult validationResult)
             : base(validationResult)
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
