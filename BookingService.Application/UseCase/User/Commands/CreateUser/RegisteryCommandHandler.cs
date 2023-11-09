using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using MediatR;

namespace BookingService.Application.UseCase.User.Commands.CreateUser
{
    public class RegisteryCommandHandler : IRequestHandler<RegisteryCommand, RegisteryCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public RegisteryCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
        public async Task<RegisteryCommandResponse> Handle(RegisteryCommand request, CancellationToken cancellationToken)
        {
            var validator = await new RegisteryCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validator.IsValid)
                return new RegisteryCommandResponse(validator);

            if (userRepository.GetUserByLoginAsync(request.Login).Result != null)
                return new RegisteryCommandResponse("User with this login alredy exist", false);

            if (userRepository.GetUserByEmailAsync(request.Email).Result != null)
                return new RegisteryCommandResponse("User with this email alredy exist", false);

            var user = mapper.Map<Domain.Entities.User>(request);

            user = await userRepository.AddAsync(user);

            return new RegisteryCommandResponse(user.Id);
        }
    }
}
