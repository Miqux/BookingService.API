using BookingService.Application.Common;
using MediatR;

namespace BookingService.Application.UseCase.Service.Commands.DeleteService
{
    public class DeleteServiceCommand : IRequest<BaseResponse>
    {
        public int ServiceId { get; set; }
    }
}
