using AutoMapper;
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
        }
    }
}
