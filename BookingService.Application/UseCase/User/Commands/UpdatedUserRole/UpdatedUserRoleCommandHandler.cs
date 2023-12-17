using BookingService.Application.Common;
using BookingService.Application.Contracts.Persistance;
using FluentValidation.Results;
using MediatR;

namespace BookingService.Application.UseCase.User.Commands.UpdatedUserRole
{
    public class UpdatedUserRoleCommandHandler : IRequestHandler<UpdatedUserRoleCommand, BaseResponse>
    {
        private readonly IUserRepository userRepository;

        public UpdatedUserRoleCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<BaseResponse> Handle(UpdatedUserRoleCommand request, CancellationToken cancellationToken)
        {
            var validator = await new UpdatedUserRoleCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validator.IsValid)
                return new BaseResponse(validator);

            var user = await userRepository.GetByIdAsync(request.Id);

            if (user == null)
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
