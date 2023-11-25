using BookingService.Domain.Entities.Base;

namespace BookingService.Domain.Entities
{
    public class Company : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public Address? Address { get; set; }
        public User CompanyBoss { get; set; } = new();
    }
}
