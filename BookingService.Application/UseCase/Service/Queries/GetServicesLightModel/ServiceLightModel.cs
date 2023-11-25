using static BookingService.Domain.Entities.Enums;

namespace BookingService.Application.UseCase.Service.Queries.GetServicesLightModel
{
    public class ServiceLightModel
    {
        public int Id { get; set; }
        public string ComapnyName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public ServiceType Type { get; set; }
    }
}
