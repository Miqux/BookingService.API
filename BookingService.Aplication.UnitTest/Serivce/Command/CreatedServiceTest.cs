using AutoMapper;
using BookingService.Aplication.UnitTest.Company;
using BookingService.Aplication.UnitTest.Employee;
using BookingService.Application.Contracts.Persistance;
using BookingService.Application.Mapper;
using Moq;

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
    }
}
