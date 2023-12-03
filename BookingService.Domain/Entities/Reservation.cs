using BookingService.Domain.Entities.Base;

namespace BookingService.Domain.Entities
{
    public class Reservation : BaseAuditableEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Service? Service { get; set; }
        public User? User { get; set; }
    }
}
