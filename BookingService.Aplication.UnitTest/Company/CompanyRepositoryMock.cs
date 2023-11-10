using BookingService.Aplication.UnitTest.Common;
using BookingService.Application.Contracts.Persistance;
using Moq;

namespace BookingService.Aplication.UnitTest.Company
{
    public class CompanyRepositoryMock
    {
        public static Mock<ICompanyRepository> GetCompanyRepository(bool empty = false)
        {
            var company = empty ? new List<Domain.Entities.Company>() : GetCompanies();

            var mockCompanyRepository = new Mock<ICompanyRepository>();
            mockCompanyRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(company);

            mockCompanyRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
            (int id) =>
            {
                var cat = company.FirstOrDefault(c => c.Id == id);
                return cat;
            });

            mockCompanyRepository.Setup(repo => repo.AddAsync(It.IsAny<Domain.Entities.Company>())).ReturnsAsync(
                (Domain.Entities.Company user) =>
                {
                    company.Add(user);
                    return user;
                });

            mockCompanyRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Domain.Entities.Company>())).Callback
                <Domain.Entities.Company>((entity) => company.Remove(entity));

            mockCompanyRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Domain.Entities.Company>())).Callback
                <Domain.Entities.Company>((entity) => { company.Remove(entity); company.Add(entity); });

            return mockCompanyRepository;
        }

        private static List<Domain.Entities.Company> GetCompanies()
        {
            var list = new List<Domain.Entities.Company>();

            var comapny1 = new Domain.Entities.Company()
            {
                Id = 1,
                CreatedBy = "Mark",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                Name = "Firma1",
                Address = new Domain.Entities.Address()
                {
                    Id = 1,
                    CreatedBy = "Mark",
                    CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                    LastModifiedBy = string.Empty,
                    LastModifiedDate = null,
                    City = "Warszawa",
                    Street = "Marszałkowska",
                    Zipcode = "21-111",
                    HouseNumber = 12,
                    ApartmentNumber = 0
                },
                CompanyBoss = new Domain.Entities.User()
                {
                    Id = 1,
                    CreatedBy = "Mark",
                    CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                    LastModifiedBy = string.Empty,
                    LastModifiedDate = null,
                    Name = "Warszawa",
                    LastName = "Marszałkowska",
                    Role = Domain.Entities.Enums.UserRole.User,
                    Login = "test1",
                    Password = "password1",
                    Email = "Email1@gmail.com"
                },
                Employees = new List<Domain.Entities.Employee>()
            };
            var temp = new List<Domain.Entities.Employee>()
            {
                new Domain.Entities.Employee()
                {
                    Id = 1,
                    CreatedBy = "Mark",
                    CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                    LastModifiedBy = string.Empty,
                    LastModifiedDate = null,
                    Name = "Pracownik1",
                    LastName = "NazwikoPracownik1"
                }
            };
            comapny1.Employees = temp;
            list.Add(comapny1);

            var comapny2 = new Domain.Entities.Company()
            {
                Id = 2,
                CreatedBy = "Mark",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                Name = "Firma2",
                Address = new Domain.Entities.Address()
                {
                    Id = 2,
                    CreatedBy = "Admin",
                    CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                    LastModifiedBy = string.Empty,
                    LastModifiedDate = null,
                    City = "Siedlce",
                    Street = "Sokołowksa",
                    Zipcode = "12-124",
                    HouseNumber = 66,
                    ApartmentNumber = 4
                },
                CompanyBoss = new Domain.Entities.User()
                {
                    Id = 2,
                    CreatedBy = "Mark2",
                    CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                    LastModifiedBy = string.Empty,
                    LastModifiedDate = null,
                    Name = "Warszawa2",
                    LastName = "Marszałkowska2",
                    Role = Domain.Entities.Enums.UserRole.User,
                    Login = "test2",
                    Password = "password2",
                    Email = "Email2@gmail.com"
                },
                Employees = new List<Domain.Entities.Employee>()
            };
            comapny2.Employees.ToList().Add(new Domain.Entities.Employee()
            {
                Id = 2,
                CreatedBy = "Mark",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                Name = "Pracownik2",
                LastName = "NazwikoPracownik2"
            });
            list.Add(comapny2);

            var comapny3 = new Domain.Entities.Company()
            {
                Id = 3,
                CreatedBy = "Mark",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                Name = "Firma3",
                Address = new Domain.Entities.Address()
                {
                    Id = 3,
                    CreatedBy = "Domascz",
                    CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                    LastModifiedBy = string.Empty,
                    LastModifiedDate = null,
                    City = "Międzyrzec Podlaski",
                    Street = "Warszawska",
                    Zipcode = "21-560",
                    HouseNumber = 77,
                    ApartmentNumber = 0
                },
                CompanyBoss = new Domain.Entities.User()
                {
                    Id = 3,
                    CreatedBy = "Mark3",
                    CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                    LastModifiedBy = string.Empty,
                    LastModifiedDate = null,
                    Name = "Warszawa3",
                    LastName = "Marszałkowska3",
                    Role = Domain.Entities.Enums.UserRole.User,
                    Login = "test3",
                    Password = "password3",
                    Email = "Email3@gmail.com"
                },
                Employees = new List<Domain.Entities.Employee>()
            };
            comapny3.Employees.ToList().Add(new Domain.Entities.Employee()
            {
                Id = 3,
                CreatedBy = "Mark",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                Name = "Pracownik3",
                LastName = "NazwikoPracownik3"
            });
            comapny3.Employees.ToList().Add(new Domain.Entities.Employee()
            {
                Id = 4,
                CreatedBy = "Mark4",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                Name = "Pracownik4",
                LastName = "NazwikoPracownik4"
            });
            list.Add(comapny3);

            return list;
        }
    }
}
