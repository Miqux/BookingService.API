using BookingService.Application.Common;
using FluentValidation.Results;

namespace BookingService.Application.UseCase.Company.Commands.CreateCompany
{
    public class CreateCompanyCommandResponse : BaseResponse
    {
        public int? CompanyId { get; set; }
        public CreateCompanyCommandResponse() : base()
        { }

        public CreateCompanyCommandResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public CreateCompanyCommandResponse(string message)
        : base(message)
        { }

        public CreateCompanyCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public CreateCompanyCommandResponse(int companyId)
        {
            CompanyId = companyId;
        }
    }
}
