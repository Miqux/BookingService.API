using BookingService.Application.Common;

namespace BookingService.Application.UseCase.Service.Commands.DeleteService
{
    public class DeleteServiceCommand : IRequest<BaseResponse>
    {
        public int ServiceId { get; set; }
    }
}
