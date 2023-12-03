using BookingService.Domain.Entities.Base;
using static BookingService.Domain.Entities.Enums;

namespace BookingService.Domain.Entities
{
    public class Service : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int DurationInMinutes { get; set; }
        public ServiceType Type { get; set; }
        public Company Company { get; set; } = new();
        public bool Active { get; set; }
    }
}
