namespace BookingService.Application.Contracts.Persistance
{
    public interface ICompanyRepository : IAsyncRepository<Company>
    {
        Task<Company?> GetByUserId(int userId);
        Task<Company?> GetByName(string name);
        Task<Company?> GetWithChildren(int id);
    }
}
