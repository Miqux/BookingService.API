namespace BookingService.Application.UseCase.Reservation.Queries.GetIncomingReservations
{
    public class GetIncomingReservationsQuery : IRequest<List<IncomingReservationViewModel>>
    {
        public int UserId { get; set; }
    }
}
