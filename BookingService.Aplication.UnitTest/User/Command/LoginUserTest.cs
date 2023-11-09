using BookingService.Application.Contracts.Persistance;
using BookingService.Application.Contracts.Security;
using BookingService.Application.UseCase.User.Commands.Login;
using Moq;
using Shouldly;
using Xunit;

namespace BookingService.Aplication.UnitTest.User.Command
{
    public class LoginUserTest
    {
        private readonly Mock<IUserRepository> userRepository;
        private readonly Mock<IPasswordHashService> passwordHashService;
        private readonly Mock<IJwtProvider> jwtProvider;
        public LoginUserTest()
        {
            userRepository = UserRepositoryMock.GetUserRepository();
            passwordHashService = new Mock<IPasswordHashService>();
            jwtProvider = new Mock<IJwtProvider>();

            passwordHashService.Setup(service => service.ComparePassword(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string password1, string password2) =>
                {
                    return password1.Equals(password2);
                });

            jwtProvider.Setup(provider => provider.Generate(It.IsAny<Domain.Entities.User>()))
                .Returns((Domain.Entities.User user) =>
                {
                    return user.Login + user.Email + user.Name;
                });
        }

        [Fact]
        public async Task Handle_ValidLoginAndPassword_TokenGenerated()
        {
            var handler = new LoginCommandHandler(userRepository.Object, passwordHashService.Object, jwtProvider.Object);
            var user = userRepository.Object.GetUserByLoginAsync("test1").Result;
            string token = user?.Login + user?.Email + user?.Name;

            var response = await handler.Handle(new LoginCommand()
            {
                Login = "test1",
                Password = "password1"
            }, CancellationToken.None);

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            response.Token.ShouldBe(token);
        }
        [Fact]
        public async Task Handle_InvalidLogin_TokenNotGenerated()
        {
            var handler = new LoginCommandHandler(userRepository.Object, passwordHashService.Object, jwtProvider.Object);

            var response = await handler.Handle(new LoginCommand()
            {
                Login = "incorrect",
                Password = "password1"
            }, CancellationToken.None);

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(0);
            response.Token.ShouldBe(string.Empty);
        }
        [Fact]
        public async Task Handle_InvalidPassword_TokenNotGenerated()
        {
            var handler = new LoginCommandHandler(userRepository.Object, passwordHashService.Object, jwtProvider.Object);

            var response = await handler.Handle(new LoginCommand()
            {
                Login = "test1",
                Password = "incorrectPassword"
            }, CancellationToken.None);

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(0);
            response.Token.ShouldBe(string.Empty);
        }
        [Fact]
        public async Task Handle_InvalidPasswordAndLogin_TokenNotGenerated()
        {
            var handler = new LoginCommandHandler(userRepository.Object, passwordHashService.Object, jwtProvider.Object);

            var response = await handler.Handle(new LoginCommand()
            {
                Login = "incorrenct",
                Password = "incorrenct"
            }, CancellationToken.None);

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(0);
            response.Token.ShouldBe(string.Empty);
        }
    }
}
