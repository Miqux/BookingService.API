using BookingService.Application.Common;
using FluentValidation.Results;

namespace BookingService.Application.UseCase.Service.Commands.AddService
{
    public class CreatedServiceCommandResponse : BaseResponse
    {
        public int? ServiceId { get; set; }

        public CreatedServiceCommandResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public CreatedServiceCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public CreatedServiceCommandResponse(int serviceId)
        {
            ServiceId = serviceId;
        }
    }
}
