using MediatR;

namespace BookingService.Application.UseCase.Company.Commands.UpdateComapnyWithAddress
{
    public class UpdateCompanyWithAddressCommand : IRequest<UpdateCompanyWithAddressCommandResponse>
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
