using BookingService.Application.Contracts.Persistance;
using BookingService.Application.Contracts.Security;

namespace BookingService.Application.UseCase.User.Commands.CreateUser
{
    public class RegisteryCommandHandler : IRequestHandler<RegisteryCommand, RegisteryCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IPasswordHashService passwordHashService;

        public RegisteryCommandHandler(IMapper mapper, IUserRepository userRepository, IPasswordHashService passwordHashService)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.passwordHashService = passwordHashService;
        }
        public async Task<RegisteryCommandResponse> Handle(RegisteryCommand request, CancellationToken cancellationToken)
        {
            var validator = await new RegisteryCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validator.IsValid)
                return new RegisteryCommandResponse(validator);

            if (userRepository.GetUserByLoginAsync(request.Login).Result != null)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("Login", "User with this login alredy exist"));
                return new RegisteryCommandResponse(validation);
            }
            if (userRepository.GetUserByEmailAsync(request.Email).Result != null)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("Email", "User with this email alredy exist"));
                return new RegisteryCommandResponse(validation);
            }

            request.Password = passwordHashService.Encrypt(request.Password);
            var user = mapper.Map<Domain.Entities.User>(request);
            user = await userRepository.AddAsync(user);

            return new RegisteryCommandResponse(user.Id);
        }
    }
}
