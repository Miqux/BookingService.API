using BookingService.Aplication.UnitTest.Common;
using BookingService.Application.Contracts.Persistance;
using Moq;

namespace BookingService.Aplication.UnitTest.User
{
    public class UserRepositoryMock
    {
        public static Mock<IUserRepository> GetUserRepository(bool empty = false)
        {
            var users = empty ? new List<Domain.Entities.User>() : GetUsers();

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(users);

            mockUserRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
            (int id) =>
            {
                var cat = users.FirstOrDefault(c => c.Id == id);
                return cat;
            });

            mockUserRepository.Setup(repo => repo.AddAsync(It.IsAny<Domain.Entities.User>())).ReturnsAsync(
                (Domain.Entities.User user) =>
                {
                    users.Add(user);
                    return user;
                });

            mockUserRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Domain.Entities.User>())).Callback
                <Domain.Entities.User>((entity) => users.Remove(entity));

            mockUserRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Domain.Entities.User>())).Callback
                <Domain.Entities.User>((entity) => { users.Remove(entity); users.Add(entity); });

            mockUserRepository.Setup(repo => repo.GetUserByLoginAsync(It.IsAny<string>())).ReturnsAsync(
            (string login) =>
            {
                var cat = users.FirstOrDefault(c => c.Login == login);
                return cat;
            });

            mockUserRepository.Setup(repo => repo.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync(
            (string email) =>
            {
                var cat = users.FirstOrDefault(c => c.Email == email);
                return cat;
            });

            return mockUserRepository;
        }

        private static List<Domain.Entities.User> GetUsers()
        {
            var list = new List<Domain.Entities.User>();

            var address1 = new Domain.Entities.User()
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
            };
            list.Add(address1);

            var address2 = new Domain.Entities.User()
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
            };
            list.Add(address2);

            var address3 = new Domain.Entities.User()
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
            };
            list.Add(address3);

            var address4 = new Domain.Entities.User()
            {
                Id = 4,
                CreatedBy = "Mark4",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                Name = "Warszawa4",
                LastName = "Marszałkowska4",
                Role = Domain.Entities.Enums.UserRole.User,
                Login = "test4",
                Password = "password4",
                Email = "Email4@gmail.com"
            };
            list.Add(address4);

            var address5 = new Domain.Entities.User()
            {
                Id = 5,
                CreatedBy = "Mark5",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                Name = "Warszawa5",
                LastName = "Marszałkowska5",
                Role = Domain.Entities.Enums.UserRole.User,
                Login = "test5",
                Password = "password5",
                Email = "Email5@gmail.com"
            };
            list.Add(address5);

            return list;
        }
    }
}

