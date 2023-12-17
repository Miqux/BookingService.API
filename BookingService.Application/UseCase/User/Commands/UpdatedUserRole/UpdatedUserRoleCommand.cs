using BookingService.Application.Common;
using MediatR;
using static BookingService.Domain.Entities.Enums;

namespace BookingService.Application.UseCase.User.Commands.UpdatedUserRole
{
    public class UpdatedUserRoleCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public UserRole Role { get; set; }
    }
}
