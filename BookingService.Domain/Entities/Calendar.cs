using BookingService.Domain.Entities.Base;

namespace BookingService.Domain.Entities
{
    public class Calendar : BaseAuditableEntity
    {
        public string Private_key { get; set; } = string.Empty;
        public string Client_email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
