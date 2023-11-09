using BookingService.Domain.Entities.Base;

namespace BookingService.Domain.Entities
{
    public class Service : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int DurationInMinutes { get; set; }
        public Company? Company { get; set; }
        public Employee? Employee { get; set; }
    }
}
