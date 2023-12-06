using MediatR;

namespace BookingService.Application.UseCase.Company.Command.UpdatedComapnyWithAddress
{
    public class UpdatedCompanyWithAddressCommand : IRequest<UpdatedCompanyWithAddressCommandResponse>
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty;
        public int HouseNumber { get; set; }
        public int? ApartmentNumber { get; set; }
    }
}
