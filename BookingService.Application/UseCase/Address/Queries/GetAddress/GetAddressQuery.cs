using MediatR;

namespace BookingService.Application.UseCase.Address.Queries.GetAddress
{
    public class GetAddressQuery : IRequest<AddressViewModel>
    {
        public int Id { get; set; }
    }
}
