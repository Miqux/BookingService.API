using BookingService.Domain.Entities.Base;
using static BookingService.Domain.Entities.Enums;

namespace BookingService.Domain.Entities
{
    public class User : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public string Nick { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Emial { get; set; } = string.Empty;
    }
}
