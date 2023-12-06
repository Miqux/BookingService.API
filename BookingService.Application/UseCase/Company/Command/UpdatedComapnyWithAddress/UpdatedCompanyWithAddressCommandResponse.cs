using BookingService.Application.Common;
using FluentValidation.Results;

namespace BookingService.Application.UseCase.Company.Command.UpdatedComapnyWithAddress
{
    public class UpdatedCompanyWithAddressCommandResponse : BaseResponse
    {
        public UpdatedCompanyWithAddressCommandResponse() : base()
        { }

        public UpdatedCompanyWithAddressCommandResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public UpdatedCompanyWithAddressCommandResponse(string message)
        : base(message)
        { }

        public UpdatedCompanyWithAddressCommandResponse(string message, bool success)
            : base(message, success)
        { }
    }
}
