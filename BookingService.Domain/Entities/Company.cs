using BookingService.Domain.Entities.Base;

namespace BookingService.Domain.Entities
{
    public class Company : BaseAuditableEntity
    {
        public int Name { get; set; }
        public Address? Address { get; set; }
        public User? CompanyBoss { get; set; }
        public IEnumerable<CompanyEmployee>? Employees { get; set; }
    }
}
