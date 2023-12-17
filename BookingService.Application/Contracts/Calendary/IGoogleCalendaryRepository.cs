using BookingService.Domain.ValueObject;

namespace BookingService.Application.Contracts.Calendary
{
    public interface IGoogleCalendaryRepository
    {
        Task<bool> AddServiceEvent(ServiceEvent reservation);
        Task<List<ServiceTime>> GetWorkingHoursByDateAndCalendarId(DateOnly dateOnly, int calendarId);
        Task<List<ServiceTime>> GetBusyHoursByDateAndCalendarId(DateOnly dateOnly, int calendarId);
        Task<bool> CheckDateTimeIsAvailable(ServiceEvent serviceEvent);
        Task<bool> DeleteEvent(DateTime startDate, DateTime endDate, int calendarId);
    }
}
