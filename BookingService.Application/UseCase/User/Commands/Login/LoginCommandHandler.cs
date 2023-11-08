using BookingService.Application.Contracts.Persistance;
using BookingService.Application.Contracts.Security;
using MediatR;

namespace BookingService.Application.UseCase.User.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHashService passwordHashService;
        private readonly IJwtProvider jwtProvider;

        public LoginCommandHandler(IUserRepository userRepository, IPasswordHashService passwordHashService
            , IJwtProvider jwtProvider)
        {
            this.userRepository = userRepository;
            this.passwordHashService = passwordHashService;
            this.jwtProvider = jwtProvider;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByNickAsync(request.Login);

            if (user == null) return new LoginCommandResponse("User not found", false);

            if (!passwordHashService.ComparePassword(request.Password, user.Password))
                return new LoginCommandResponse("Incorrect password", false);

            string token = jwtProvider.Generate(user);

            return new LoginCommandResponse(token);
        }
    }
}
