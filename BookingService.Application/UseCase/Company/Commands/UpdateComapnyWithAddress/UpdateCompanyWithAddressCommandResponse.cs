using BookingService.Application.Common;

namespace BookingService.Application.UseCase.Company.Commands.UpdateComapnyWithAddress
{
    public class UpdateCompanyWithAddressCommandResponse : BaseResponse
    {
        public UpdateCompanyWithAddressCommandResponse() : base()
        { }

        public UpdateCompanyWithAddressCommandResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public UpdateCompanyWithAddressCommandResponse(string message)
        : base(message)
        { }

        public UpdateCompanyWithAddressCommandResponse(string message, bool success)
            : base(message, success)
        { }
    }
}
