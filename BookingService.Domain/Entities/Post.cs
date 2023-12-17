using BookingService.Domain.Entities.Base;

namespace BookingService.Domain.Entities
{
    public class Post : BaseAuditableEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
