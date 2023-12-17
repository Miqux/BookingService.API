using BookingService.Application.Contracts.Persistance;
using BookingService.Domain.Entities;

namespace BookingService.Infrastructure.Persistence.Repository
{
    public class PostRepository : AsyncRepository<Post>, IPostRepository
    {
        public PostRepository(BookingServiceContext bookingServiceContext) : base(bookingServiceContext)
        {
        }
    }
}
