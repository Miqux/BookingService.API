using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using BookingService.Application.Mapper;
using BookingService.Application.UseCase.Address.Commands.CreateAddress;
using Moq;
using Shouldly;
using Xunit;

namespace BookingService.Aplication.UnitTest.Address.Commands
{
    public class CreateAddressTest
    {
        private readonly Mock<IAddressRepository> addressRepository;
        private readonly IMapper mapper;

        public CreateAddressTest()
        {
            addressRepository = AddressRepositoryMocks.GetAddressRepository();
            mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingConfiguration>();
            }).CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidAddress_AddedToAddressRepo()
        {
            var handler = new CreatedAddressCommandHandler(addressRepository.Object, mapper);
            var allAddressBeforeCount = (await addressRepository.Object.GetAllAsync()).Count;

            var response = await handler.Handle(new CreatedAddressCommand()
            {
                City = "Warszawa",
                Street = "Testowa",
                Zipcode = "21-213",
                HouseNumber = 1,
                ApartmentNumber = 2
            }
            , CancellationToken.None);

            var allAddress = await addressRepository.Object.GetAllAsync();
            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            allAddress.Count.ShouldBe(allAddressBeforeCount + 1);
            response.AddressId.ShouldNotBeNull();
        }
        [Fact]
        public async Task Handle_NotValidAddress_DontAddedToAddressRepo()
        {
            var handler = new CreatedAddressCommandHandler(addressRepository.Object, mapper);
            var allAddressBeforeCount = (await addressRepository.Object.GetAllAsync()).Count;

            var response = await handler.Handle(new CreatedAddressCommand()
            {
                City = "Wa",
                Street = "T",
                Zipcode = "21-213",
                HouseNumber = 1,
                ApartmentNumber = 2
            }
            , CancellationToken.None);

            var allAddress = await addressRepository.Object.GetAllAsync();
            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(2);
            allAddress.Count.ShouldBe(allAddressBeforeCount);
            response.AddressId.ShouldBeNull();
        }

        [Fact]
        public async Task Handle_HouseNumberLessThanOne_DontAddedToAddressRepo()
        {
            var handler = new CreatedAddressCommandHandler(addressRepository.Object, mapper);
            var allAddressBeforeCount = (await addressRepository.Object.GetAllAsync()).Count;

            var response = await handler.Handle(new CreatedAddressCommand()
            {
                City = "Waasda",
                Street = "Tasdasd",
                Zipcode = "21-213",
                HouseNumber = 0,
                ApartmentNumber = 2
            }
            , CancellationToken.None);

            var allAddress = await addressRepository.Object.GetAllAsync();
            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(1);
            allAddress.Count.ShouldBe(allAddressBeforeCount);
            response.AddressId.ShouldBeNull();
        }
    }
}
