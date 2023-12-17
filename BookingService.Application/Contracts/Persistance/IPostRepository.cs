using BookingService.Domain.Entities;

namespace BookingService.Application.Contracts.Persistance
{
    public interface IPostRepository : IAsyncRepository<Post>
    {
    }
}
