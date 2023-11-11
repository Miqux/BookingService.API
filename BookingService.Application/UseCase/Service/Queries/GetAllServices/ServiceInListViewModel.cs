namespace BookingService.Application.UseCase.Service.Queries.GetAllServices
{
    public class ServiceInListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int DurationInMinutes { get; set; }
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
    }
}
