using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using BookingService.Application.Mapper;
using BookingService.Application.UseCase.Address.Queries.GetAllAddress;
using Moq;
using Shouldly;
using Xunit;

namespace BookingService.Aplication.UnitTest.Address.Queries
{
    public class GetAllAddressTest
    {
        private readonly Mock<IAddressRepository> addressRepository;
        private readonly IMapper mapper;

        public GetAllAddressTest()
        {
            addressRepository = AddressRepositoryMocks.GetAddressRepository();
            mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingConfiguration>();
            }).CreateMapper();
        }
        [Fact]
        public async Task Handle_ExistsAddress_ReturnAddress()
        {
            var handler = new GetAddressListHandler(addressRepository.Object, mapper);
            var response = await handler.Handle(new GetAddressListQuery(), CancellationToken.None);

            response.ShouldNotBeEmpty();
            response.ShouldNotBeNull();
        }
        [Fact]
        public async Task Handle_AddressNotExists_ReturnEmptyListAddress()
        {
            var handler = new GetAddressListHandler(AddressRepositoryMocks.GetAddressRepository(true).Object, mapper);
            var response = await handler.Handle(new GetAddressListQuery(), CancellationToken.None);

            response.ShouldBeEmpty();
            response.ShouldNotBeNull();
        }
    }
}