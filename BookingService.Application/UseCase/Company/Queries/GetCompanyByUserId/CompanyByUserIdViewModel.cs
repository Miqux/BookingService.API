namespace BookingService.Application.UseCase.Company.Queries.GetCompanyByUserId
{
    public class CompanyByUserIdViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AddressId { get; set; }
        public int CalendarId { get; set; }
    }
}
