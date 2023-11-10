using BookingService.Aplication.UnitTest.Common;
using BookingService.Application.Contracts.Persistance;
using Moq;

namespace BookingService.Aplication.UnitTest.Employee
{
    public class EmployeeRepositoryMock
    {
        public static Mock<IEmployeeRepository> GetEmployeeRepository(bool empty = false)
        {
            var employee = empty ? new List<Domain.Entities.Employee>() : GetEmployees();

            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            mockEmployeeRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employee);

            mockEmployeeRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
            (int id) =>
            {
                var cat = employee.FirstOrDefault(c => c.Id == id);
                return cat;
            });

            mockEmployeeRepository.Setup(repo => repo.AddAsync(It.IsAny<Domain.Entities.Employee>())).ReturnsAsync(
                (Domain.Entities.Employee user) =>
                {
                    employee.Add(user);
                    return user;
                });

            mockEmployeeRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Domain.Entities.Employee>())).Callback
                <Domain.Entities.Employee>((entity) => employee.Remove(entity));

            mockEmployeeRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Domain.Entities.Employee>())).Callback
                <Domain.Entities.Employee>((entity) => { employee.Remove(entity); employee.Add(entity); });

            return mockEmployeeRepository;
        }

        private static List<Domain.Entities.Employee> GetEmployees()
        {
            var list = new List<Domain.Entities.Employee>();

            var employee1 = new Domain.Entities.Employee()
            {
                Id = 1,
                CreatedBy = "Mark",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                Name = "Pracownik1",
                LastName = "NazwikoPracownik1"
            };
            list.Add(employee1);

            var employee2 = new Domain.Entities.Employee()
            {
                Id = 2,
                CreatedBy = "Mark",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                Name = "Pracownik2",
                LastName = "NazwikoPracownik2"
            };
            list.Add(employee2);

            var employee3 = new Domain.Entities.Employee()
            {
                Id = 3,
                CreatedBy = "Mark",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                Name = "Pracownik3",
                LastName = "NazwikoPracownik3"
            };
            list.Add(employee3);

            var employee4 = new Domain.Entities.Employee()
            {
                Id = 4,
                CreatedBy = "Mark4",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                Name = "Pracownik4",
                LastName = "NazwikoPracownik4"
            };
            list.Add(employee4);

            var employee5 = new Domain.Entities.Employee()
            {
                Id = 5,
                CreatedBy = "Mark5",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                Name = "Pracownik5",
                LastName = "NazwikoPracownik5"
            };
            list.Add(employee5);

            return list;
        }
    }
}

