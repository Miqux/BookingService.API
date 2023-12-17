using BookingService.Application.Common;
using MediatR;

namespace BookingService.Application.UseCase.Reservation.Commands.DeletedReservation
{
    public class DeletedReservationCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
