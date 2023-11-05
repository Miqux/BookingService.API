using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using BookingService.Application.Mapper;
using BookingService.Application.UseCase.Address.Queries.GetAddress;
using Moq;
using Shouldly;
using Xunit;

namespace BookingService.Aplication.UnitTest.Address.Queries
{
    public class GetAddressByIdTest
    {
        private readonly Mock<IAddressRepository> addressRepository;
        private readonly IMapper mapper;

        public GetAddressByIdTest()
        {
            addressRepository = AddressRepositoryMocks.GetAddressRepository();
            mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingConfiguration>();
            }).CreateMapper();
        }
        [Fact]
        public async Task Handle_AddressExists_ReturnAddress()
        {
            var handler = new GetAddressHandler(addressRepository.Object, mapper);
            var response = await handler.Handle(new GetAddressQuery() { Id = 2 }
            , CancellationToken.None);

            response.ShouldNotBeNull();
            response.Id.ShouldBeGreaterThanOrEqualTo(0);
        }
        [Fact]
        public async Task Handle_AddressNotExists_ReturnNull()
        {
            var handler = new GetAddressHandler(addressRepository.Object, mapper);
            var response = await handler.Handle(new GetAddressQuery() { Id = -2 }
            , CancellationToken.None);

            response.ShouldBeNull();
        }
    }
}
