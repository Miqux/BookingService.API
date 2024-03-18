using BookingService.Application.Contracts.Persistance;

namespace BookingService.Application.UseCase.Address.Queries.GetAddress
{
    public class GetAddressHandler : IRequestHandler<GetAddressQuery, AddressViewModel>
    {
        private readonly IAddressRepository addressRepository;
        private readonly IMapper mapper;

        public GetAddressHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            this.addressRepository = addressRepository;
            this.mapper = mapper;
        }
        public async Task<AddressViewModel> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var address = await addressRepository.GetByIdAsync(request.Id);
            return mapper.Map<AddressViewModel>(address);
        }
    }
}
