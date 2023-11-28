using BookingService.Application.Common;
using FluentValidation.Results;

namespace BookingService.Application.UseCase.Company.Command.CreatedCompany
{
    public class CreatedCompanyCommandResponse : BaseResponse
    {
        public int? CompanyId { get; set; }
        public CreatedCompanyCommandResponse() : base()
        { }

        public CreatedCompanyCommandResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public CreatedCompanyCommandResponse(string message)
        : base(message)
        { }

        public CreatedCompanyCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public CreatedCompanyCommandResponse(int companyId)
        {
            CompanyId = companyId;
        }
    }
}
