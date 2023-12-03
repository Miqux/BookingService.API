using BookingService.Application.Contracts.Persistance;
using BookingService.Domain.Entities;

namespace BookingService.Infrastructure.Persistence.Repository
{
    public class ReservationRepository : AsyncRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(BookingServiceContext bookingServiceContext) : base(bookingServiceContext)
        {
        }
    }
}
