using BookingService.Domain.Entities.Base;

namespace BookingService.Domain.Entities
{
    public class Employee : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public TimeOnly StartDay { get; set; }
        public TimeOnly EndDay { get; set; }
    }
}
