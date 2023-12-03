using BookingService.Application.Contracts.Persistance;
using BookingService.Domain.Entities;

namespace BookingService.Infrastructure.Persistence.Repository
{
    public class CalendarRepository : AsyncRepository<Calendar>, ICalendarRepository
    {
        public CalendarRepository(BookingServiceContext bookingServiceContext) : base(bookingServiceContext)
        {
        }
    }
}
