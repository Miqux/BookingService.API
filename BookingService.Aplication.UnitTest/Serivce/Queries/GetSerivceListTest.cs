using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using BookingService.Application.Mapper;
using BookingService.Application.UseCase.Service.Queries.GetAllServices;
using Moq;
using Shouldly;
using Xunit;

namespace BookingService.Aplication.UnitTest.Serivce.Queries
{
    public class GetSerivceListTest
    {
        private readonly Mock<IServiceRepository> serviceRepository;
        private readonly IMapper mapper;

        public GetSerivceListTest()
        {
            serviceRepository = ServiceRepositoryMock.GetServiceRepository();
            mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingConfiguration>();
            }).CreateMapper();
        }
        [Fact]
        public async Task Handle_ExistsServices_ReturnServices()
        {
            var handler = new GetServicesListHandler(mapper, serviceRepository.Object);
            var response = await handler.Handle(new GetServicesListQuery(), CancellationToken.None);

            response.ShouldNotBeEmpty();
            response.ShouldNotBeNull();
            response.Count.ShouldBe(serviceRepository.Object.GetAllAsync().Result.Count);
        }
        [Fact]
        public async Task Handle_ServicesNotExist_ReturnEmptyListOfServices()
        {
            var handler = new GetServicesListHandler(mapper, ServiceRepositoryMock.GetServiceRepository(true).Object);
            var response = await handler.Handle(new GetServicesListQuery(), CancellationToken.None);

            response.ShouldBeEmpty();
            response.ShouldNotBeNull();
        }
    }
}
