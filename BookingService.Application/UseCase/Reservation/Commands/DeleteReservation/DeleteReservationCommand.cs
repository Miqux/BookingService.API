using BookingService.Application.Common;
using MediatR;

namespace BookingService.Application.UseCase.Reservation.Commands.DeleteReservation
{
    public class DeleteReservationCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
