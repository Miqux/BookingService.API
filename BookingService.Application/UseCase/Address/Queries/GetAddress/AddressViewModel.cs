namespace BookingService.Application.UseCase.Address.Queries.GetAddress
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; } = string.Empty;
        public DateTime? LastModifiedDate { get; set; }
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty;
        public int HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
