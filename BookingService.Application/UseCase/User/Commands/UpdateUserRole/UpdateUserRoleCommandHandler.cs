using BookingService.Application.Common;
using BookingService.Application.Contracts.Persistance;
using FluentValidation.Results;
using MediatR;

namespace BookingService.Application.UseCase.User.Commands.UpdateUserRole
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, BaseResponse>
    {
        private readonly IUserRepository userRepository;

        public UpdateUserRoleCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<BaseResponse> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var validator = await new UpdateUserRoleCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validator.IsValid)
                return new BaseResponse(validator);

            var user = await userRepository.GetByIdAsync(request.Id);

            if (user is null)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("Id", "User doeasn't exist"));
                return new BaseResponse(validation);
            }

            user.Role = request.Role;

            await userRepository.UpdateAsync(user);

            return new BaseResponse("User updated");
        }
    }
}
