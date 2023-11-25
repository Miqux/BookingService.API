using BookingService.Aplication.UnitTest.Common;
using BookingService.Application.Contracts.Persistance;
using Moq;

namespace BookingService.Aplication.UnitTest.Serivce
{
    public class ServiceRepositoryMock
    {
        public static Mock<IServiceRepository> GetServiceRepository(bool empty = false)
        {
            var services = empty ? new List<Domain.Entities.Service>() : GetServices();

            var mockServiceRepository = new Mock<IServiceRepository>();
            mockServiceRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(services);

            mockServiceRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
            (int id) =>
            {
                var cat = services.FirstOrDefault(c => c.Id == id);
                return cat;
            });

            mockServiceRepository.Setup(repo => repo.AddAsync(It.IsAny<Domain.Entities.Service>())).ReturnsAsync(
                (Domain.Entities.Service user) =>
                {
                    services.Add(user);
                    return user;
                });

            mockServiceRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Domain.Entities.Service>())).Callback
                <Domain.Entities.Service>((entity) => services.Remove(entity));

            mockServiceRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Domain.Entities.Service>())).Callback
                <Domain.Entities.Service>((entity) => { services.Remove(entity); services.Add(entity); });

            return mockServiceRepository;
        }

        private static List<Domain.Entities.Service> GetServices()
        {
            var list = new List<Domain.Entities.Service>();

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
                    Role = Domain.Entities.Enums.UserRole.CompanyBoss,
                    Login = "test1",
                    Password = "password1",
                    Email = "Email1@gmail.com"
                }
            };

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
                    Role = Domain.Entities.Enums.UserRole.CompanyBoss,
                    Login = "test2",
                    Password = "password2",
                    Email = "Email2@gmail.com"
                }
            };

            var service1 = new Domain.Entities.Service()
            {
                Id = 1,
                CreatedBy = "Mark",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                Name = "Usługa 1",
                Type = Domain.Entities.Enums.ServiceType.Haircut,
                Cost = 100,
                DurationInMinutes = 60,
                Company = comapny1
            };
            list.Add(service1);

            var service2 = new Domain.Entities.Service()
            {
                Id = 2,
                CreatedBy = "Mark",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                Name = "Usługa 2",
                Cost = 150.20M,
                DurationInMinutes = 45,
                Type = Domain.Entities.Enums.ServiceType.Combo,
                Company = comapny2
            };
            list.Add(service2);

            return list;
        }
    }
}
