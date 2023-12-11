using BookingService.Application.Contracts.Persistance;
using BookingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Persistence.Repository
{
    public class ReservationRepository : AsyncRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(BookingServiceContext bookingServiceContext) : base(bookingServiceContext)
        {
        }

        public async Task<List<Reservation>> GetCompletedWithChildrenByUserId(int userId)
        {
            return await bookingServiceContext.Reservation.Where(x => x.EndDate < DateTime.Now && x.User != null && x.User.Id == userId)
                .Include(x => x.User).Include(x => x.Service).ThenInclude(x => x != null ? x.Company : null).ToListAsync();
        }

        public async Task<List<Reservation>> GetIncomingWithChildrenByUserId(int userId)
        {
            return await bookingServiceContext.Reservation.Where(x => x.StartDate > DateTime.Now && x.User != null && x.User.Id == userId)
                .Include(x => x.User).Include(x => x.Service).ThenInclude(x => x != null ? x.Company : null).ToListAsync();
        }
    }
}
