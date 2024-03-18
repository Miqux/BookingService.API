using BookingService.Application.Common;
using FluentValidation.Results;

namespace BookingService.Application.UseCase.Service.Commands.CreateService
{
    public class CreateServiceCommandResponse : BaseResponse
    {
        public int? ServiceId { get; set; }

        public CreateServiceCommandResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public CreateServiceCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public CreateServiceCommandResponse(int serviceId)
        {
            ServiceId = serviceId;
        }
    }
}
