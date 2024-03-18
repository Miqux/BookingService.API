using BookingService.Application.Common;

namespace BookingService.Application.UseCase.Reservation.Commands.DeleteReservation
{
    public class DeleteReservationCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
