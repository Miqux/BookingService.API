using BookingService.Domain.Entities.Base;

namespace BookingService.Domain.Entities
{
    public class Address : BaseAuditableEntity
    {
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty;
        public int HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
