using BookingService.Domain.Entities.Base;

namespace BookingService.Domain.Entities
{
    public class Reservation : BaseAuditableEntity
    {
        public DateTime Date { get; set; }
        public Service? Service { get; set; }
        public User? User { get; set; }
    }
}
