using BookingService.Application.Contracts.Persistance;

namespace BookingService.Persistence.Repository
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        private StaticContext context;
        public AsyncRepository()
        {
            context = new StaticContext();
        }
        public async virtual Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async virtual Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
