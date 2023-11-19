using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using BookingService.Application.Mapper;
using BookingService.Application.UseCase.User.Queries.GetUser;
using Moq;
using Shouldly;
using Xunit;

namespace BookingService.Aplication.UnitTest.User.Queries
{
    public class GetUserByIdTest
    {
        private readonly Mock<IUserRepository> userRepository;
        private readonly IMapper mapper;

        public GetUserByIdTest()
        {
            userRepository = UserRepositoryMock.GetUserRepository();
            mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingConfiguration>();
            }).CreateMapper();
        }
        [Fact]
        public async Task Handle_AddressExists_ReturnAddress()
        {
            var handler = new GetUserHandler(userRepository.Object, mapper);
            var response = await handler.Handle(new GetUserQuery() { Id = 2 }
            , CancellationToken.None);

            response.ShouldNotBeNull();
            response.Id.ShouldBeGreaterThanOrEqualTo(0);
        }
        [Fact]
        public async Task Handle_AddressNotExists_ReturnNull()
        {
            var handler = new GetUserHandler(userRepository.Object, mapper);
            var response = await handler.Handle(new GetUserQuery() { Id = 999 }
            , CancellationToken.None);

            response.ShouldBeNull();
        }
        [Fact]
        public async Task Handle_WrongId_ReturnNull()
        {
            var handler = new GetUserHandler(userRepository.Object, mapper);
            var response = await handler.Handle(new GetUserQuery() { Id = -999 }
            , CancellationToken.None);

            response.ShouldBeNull();
        }
    }
}
