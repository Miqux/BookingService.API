namespace BookingService.Application.UseCase.Reservation.Queries.GetCompletedReservations
{
    public class GetCompletedReservationsQuery : IRequest<List<CompletedReservationViewModel>>
    {
        public int UserId { get; set; }
    }
}
