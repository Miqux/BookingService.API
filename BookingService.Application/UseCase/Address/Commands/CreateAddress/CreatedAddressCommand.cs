using MediatR;

namespace BookingService.Application.UseCase.Address.Commands.CreateAddress
{
    public class CreatedAddressCommand : IRequest<CreatedAddressCommandResponse>
    {
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty;
        public int HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
