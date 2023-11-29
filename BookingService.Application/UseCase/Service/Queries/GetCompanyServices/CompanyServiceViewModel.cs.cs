using static BookingService.Domain.Entities.Enums;

namespace BookingService.Application.UseCase.Service.Queries.GetCompanyServices
{
    public class CompanyServiceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int DurationInMinutes { get; set; }
        public ServiceType Type { get; set; }
    }
}
