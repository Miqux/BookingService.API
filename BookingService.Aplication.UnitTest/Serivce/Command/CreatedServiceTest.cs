using AutoMapper;
using BookingService.Aplication.UnitTest.Company;
using BookingService.Aplication.UnitTest.Employee;
using BookingService.Application.Contracts.Persistance;
using BookingService.Application.Mapper;
using BookingService.Application.UseCase.Service.Commands;
using Moq;
using Shouldly;
using Xunit;

namespace BookingService.Aplication.UnitTest.Serivce.Command
{
    public class CreatedServiceTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IServiceRepository> serviceRepository;
        private readonly Mock<ICompanyRepository> companyRepository;
        private readonly Mock<IEmployeeRepository> employeeRepository;
        public CreatedServiceTest()
        {
            mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingConfiguration>();
            }).CreateMapper();
            serviceRepository = ServiceRepositoryMock.GetServiceRepository();
            companyRepository = CompanyRepositoryMock.GetCompanyRepository();
            employeeRepository = EmployeeRepositoryMock.GetEmployeeRepository();
        }

        [Fact]
        public async Task Handle_ValidService_AddedToServiceRepo()
        {
            var handler = new CreatedServiceCommandHandler(mapper, serviceRepository.Object, companyRepository.Object
                , employeeRepository.Object);

            int userCountBeforeCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new CreatedServiceCommand()
            {
                Name = "TestowaUsługa1",
                Cost = 86.4M,
                DurationInMinutes = 90,
                ComapnyId = 1,
                EmployeeId = 1
            }, CancellationToken.None);

            int userCountAfterCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            response.ServiceId.ShouldNotBeNull();
            userCountAfterCommand.ShouldBe(userCountBeforeCommand + 1);
        }
    }
}
