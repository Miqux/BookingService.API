using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using MediatR;

namespace BookingService.Application.UseCase.Address.Queries.GetAllAddress
{
    public class GetAddressListHandler : IRequestHandler<GetAddressListQuery, List<AddressInListViewModel>>
    {
        private readonly IAddressRepository addressRepository;
        private readonly IMapper mapper;

        public GetAddressListHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            this.addressRepository = addressRepository;
            this.mapper = mapper;
        }

        public async Task<List<AddressInListViewModel>> Handle(GetAddressListQuery request, CancellationToken cancellationToken)
        {
            var addreses = await addressRepository.GetAllAsync();
            return mapper.Map<List<AddressInListViewModel>>(addreses);
        }
    }
}
