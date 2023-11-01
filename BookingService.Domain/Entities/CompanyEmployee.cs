using BookingService.Domain.Entities.Base;

namespace BookingService.Domain.Entities
{
    public class CompanyEmployee : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
