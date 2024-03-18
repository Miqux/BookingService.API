using BookingService.Application.Common;

namespace BookingService.Application.UseCase.User.Commands.UpdateUserRole
{
    public class UpdateUserRoleCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public UserRole Role { get; set; }
    }
}
