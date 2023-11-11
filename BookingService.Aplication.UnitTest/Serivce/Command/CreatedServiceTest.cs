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
        [Fact]
        public async Task Handle_WrongNameService_DontAddedToServiceRepo()
        {
            var handler = new CreatedServiceCommandHandler(mapper, serviceRepository.Object, companyRepository.Object
                , employeeRepository.Object);

            int userCountBeforeCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new CreatedServiceCommand()
            {
                Name = "aa",
                Cost = 86.4M,
                DurationInMinutes = 90,
                ComapnyId = 1,
                EmployeeId = 1
            }, CancellationToken.None);

            int userCountAfterCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(1);
            response.ServiceId.ShouldBeNull();
            userCountAfterCommand.ShouldBe(userCountBeforeCommand);
        }
        [Fact]
        public async Task Handle_WrongNumberValueService_DontAddedToServiceRepo()
        {
            var handler = new CreatedServiceCommandHandler(mapper, serviceRepository.Object, companyRepository.Object
                , employeeRepository.Object);

            int userCountBeforeCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new CreatedServiceCommand()
            {
                Name = "aasdda",
                Cost = -12,
                DurationInMinutes = 0,
                ComapnyId = 1,
                EmployeeId = 1
            }, CancellationToken.None);

            int userCountAfterCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(2);
            response.ServiceId.ShouldBeNull();
            userCountAfterCommand.ShouldBe(userCountBeforeCommand);
        }
        [Fact]
        public async Task Handle_WrongValueService_DontAddedToServiceRepo()
        {
            var handler = new CreatedServiceCommandHandler(mapper, serviceRepository.Object, companyRepository.Object
                , employeeRepository.Object);

            int userCountBeforeCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new CreatedServiceCommand()
            {
                Name = "s",
                Cost = -12,
                DurationInMinutes = 0,
                ComapnyId = 1,
                EmployeeId = 1
            }, CancellationToken.None);

            int userCountAfterCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(3);
            response.ServiceId.ShouldBeNull();
            userCountAfterCommand.ShouldBe(userCountBeforeCommand);
        }
        [Fact]
        public async Task Handle_WrongCompanyId_DontAddedToServiceRepo()
        {
            var handler = new CreatedServiceCommandHandler(mapper, serviceRepository.Object, companyRepository.Object
                , employeeRepository.Object);

            int userCountBeforeCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new CreatedServiceCommand()
            {
                Name = "sasdda",
                Cost = 12,
                DurationInMinutes = 12,
                ComapnyId = 13,
                EmployeeId = 1
            }, CancellationToken.None);

            int userCountAfterCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(0);
            response.ServiceId.ShouldBeNull();
            userCountAfterCommand.ShouldBe(userCountBeforeCommand);
        }
        [Fact]
        public async Task Handle_WrongEmployeeId_DontAddedToServiceRepo()
        {
            var handler = new CreatedServiceCommandHandler(mapper, serviceRepository.Object, companyRepository.Object
                , employeeRepository.Object);

            int userCountBeforeCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new CreatedServiceCommand()
            {
                Name = "sasdda",
                Cost = 12,
                DurationInMinutes = 12,
                ComapnyId = 1,
                EmployeeId = 13
            }, CancellationToken.None);

            int userCountAfterCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(0);
            response.ServiceId.ShouldBeNull();
            userCountAfterCommand.ShouldBe(userCountBeforeCommand);
        }
        [Fact]
        public async Task Handle_GivenEmployeeIsNotAnEmployeeOfTheCompany_DontAddedToServiceRepo()
        {
            var handler = new CreatedServiceCommandHandler(mapper, serviceRepository.Object, companyRepository.Object
                , employeeRepository.Object);

            int userCountBeforeCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new CreatedServiceCommand()
            {
                Name = "sasdda",
                Cost = 12,
                DurationInMinutes = 12,
                ComapnyId = 1,
                EmployeeId = 3
            }, CancellationToken.None);

            int userCountAfterCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(0);
            response.ServiceId.ShouldBeNull();
            userCountAfterCommand.ShouldBe(userCountBeforeCommand);
        }
    }
}
