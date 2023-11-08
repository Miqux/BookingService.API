using BookingService.Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Persistence.Repository
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        public readonly BookingServiceContext bookingServiceContext;

        public AsyncRepository(BookingServiceContext bookingServiceContext)
        {
            this.bookingServiceContext = bookingServiceContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await bookingServiceContext.Set<T>().AddAsync(entity);
            await bookingServiceContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            bookingServiceContext.Set<T>().Remove(entity);
            await bookingServiceContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await bookingServiceContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await bookingServiceContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            bookingServiceContext.Entry(entity).State = EntityState.Modified;
            await bookingServiceContext.SaveChangesAsync();
        }
    }
}
