using BookingService.Application.UseCase.Reservation.Commands;
using BookingService.Domain.ValueObject;

namespace BookingService.Application.Contracts.Calendary
{
    public interface IGoogleCalendaryRepository
    {
        Task<bool> AddReservation(CreatedReservationCommand reservation);
        Task<List<ServiceTime>> GetWorkingHoursByDateAndCalendarId(DateOnly dateOnly, int calendarId);
        Task<List<ServiceTime>> GetBusyHoursByDateAndCalendarId(DateOnly dateOnly, int calendarId);
    }
}
