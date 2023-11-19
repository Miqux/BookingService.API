using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using BookingService.Application.Contracts.Security;
using BookingService.Application.Mapper;
using BookingService.Application.UseCase.User.Commands.CreateUser;
using Moq;
using Shouldly;
using Xunit;

namespace BookingService.Aplication.UnitTest.User.Command
{
    public class RegisteryUserTest
    {
        private readonly Mock<IUserRepository> userRepository;
        private readonly Mock<IPasswordHashService> passwordHashService;
        private readonly IMapper mapper;
        public RegisteryUserTest()
        {
            userRepository = UserRepositoryMock.GetUserRepository();
            mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingConfiguration>();
            }).CreateMapper();
            passwordHashService = new Mock<IPasswordHashService>();
            passwordHashService.Setup(service => service.Encrypt(It.IsAny<string>()))
                .Returns((string password) =>
                {
                    return password;
                });
        }

        [Fact]
        public async Task Handle_ValidUser_AddedToUserRepo()
        {
            var handler = new RegisteryCommandHandler(mapper, userRepository.Object, passwordHashService.Object);
            int userCount = userRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new RegisteryCommand()
            {
                Login = "testcorrect",
                Password = "passwordtestcorrect",
                Name = "Mariusz",
                LastName = "Tiktak",
                Email = "Mariusz@tiktak.pl",
                Role = Domain.Entities.Enums.UserRole.User
            }, CancellationToken.None);

            int userCountAfterCommand = userRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            response.UserId.ShouldNotBeNull();
            userCountAfterCommand.ShouldBe(userCount + 1);
        }
        [Fact]
        public async Task Handle_DontValidUser_DontAddedToUserRepo()
        {
            var handler = new RegisteryCommandHandler(mapper, userRepository.Object, passwordHashService.Object);
            int userCount = userRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new RegisteryCommand()
            {
                Login = "t",
                Password = "pastcect",
                Name = "Mardaz",
                LastName = "k",
                Email = "Mariusz@tiktak.pl",
                Role = Domain.Entities.Enums.UserRole.User
            }, CancellationToken.None);

            int userCountAfterCommand = userRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(2);
            response.UserId.ShouldBeNull();
            userCountAfterCommand.ShouldBe(userCount);
        }
        [Fact]
        public async Task Handle_DontValidUserEmail_DontAddedToUserRepo()
        {
            var handler = new RegisteryCommandHandler(mapper, userRepository.Object, passwordHashService.Object);
            int userCount = userRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new RegisteryCommand()
            {
                Login = "tasddasd",
                Password = "pastcect",
                Name = "Mardaz",
                LastName = "kasdasd",
                Email = "nieprawidlowyadresemail",
                Role = Domain.Entities.Enums.UserRole.User
            }, CancellationToken.None);

            int userCountAfterCommand = userRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(1);
            response.UserId.ShouldBeNull();
            userCountAfterCommand.ShouldBe(userCount);
        }
        [Fact]
        public async Task Handle_UserEmailAlredyExist_DontAddedToUserRepo()
        {
            var handler = new RegisteryCommandHandler(mapper, userRepository.Object, passwordHashService.Object);
            int userCount = userRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new RegisteryCommand()
            {
                Login = "testcorrect",
                Password = "passwordtestcorrect",
                Name = "Mariusz",
                LastName = "Tiktak",
                Email = "Email2@gmail.com",
                Role = Domain.Entities.Enums.UserRole.User
            }, CancellationToken.None);

            int userCountAfterCommand = userRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(1);
            response.UserId.ShouldBeNull();
            userCountAfterCommand.ShouldBe(userCount);
        }
        [Fact]
        public async Task Handle_UserLoginAlredyExist_DontAddedToUserRepo()
        {
            var handler = new RegisteryCommandHandler(mapper, userRepository.Object, passwordHashService.Object);
            int userCount = userRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new RegisteryCommand()
            {
                Login = "test3",
                Password = "passwordtestcorrect",
                Name = "Mariusz",
                LastName = "Tiktak",
                Email = "Email23123@gmail.com",
                Role = Domain.Entities.Enums.UserRole.User
            }, CancellationToken.None);

            int userCountAfterCommand = userRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(1);
            response.UserId.ShouldBeNull();
            userCountAfterCommand.ShouldBe(userCount);
        }
        [Fact]
        public async Task Handle_UserLoginAndEmailAlredyExist_DontAddedToUserRepo()
        {
            var handler = new RegisteryCommandHandler(mapper, userRepository.Object, passwordHashService.Object);
            int userCount = userRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new RegisteryCommand()
            {
                Login = "test3",
                Password = "passwordtestcorrect",
                Name = "Mariusz",
                LastName = "Tiktak",
                Email = "Email2@gmail.com",
                Role = Domain.Entities.Enums.UserRole.User
            }, CancellationToken.None);

            int userCountAfterCommand = userRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(1);
            response.UserId.ShouldBeNull();
            userCountAfterCommand.ShouldBe(userCount);
        }
    }
}
