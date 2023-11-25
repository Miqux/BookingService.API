using BookingService.Application.UseCase.Reservation.Commands;

namespace BookingService.Application.Contracts.Calendary
{
    public interface ICalendaryRepository
    {
        Task<bool> AddReservation(CreatedReservationCommand reservation);
    }
}
