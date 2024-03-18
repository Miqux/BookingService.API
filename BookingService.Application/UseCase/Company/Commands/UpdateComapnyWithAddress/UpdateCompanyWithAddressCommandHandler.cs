using BookingService.Application.Contracts.Persistance;
using FluentValidation.Results;
using MediatR;

namespace BookingService.Application.UseCase.Company.Commands.UpdateComapnyWithAddress
{
    public class UpdateCompanyWithAddressCommandHandler : IRequestHandler<UpdateCompanyWithAddressCommand, UpdateCompanyWithAddressCommandResponse>
    {
        private readonly ICompanyRepository companyRepository;

        public UpdateCompanyWithAddressCommandHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }
        public async Task<UpdateCompanyWithAddressCommandResponse> Handle(UpdateCompanyWithAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = await new UpdateCompanyWithAddressCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validator.IsValid)
                return new UpdateCompanyWithAddressCommandResponse(validator);

            var company = await companyRepository.GetWithChildren(request.CompanyId);

            if (company is null)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("CompanyId", "Comapny doasn't exist"));
                return new UpdateCompanyWithAddressCommandResponse(validation);
            }

            if (company.Address is null)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("Address", "Address doasn't exist"));
                return new UpdateCompanyWithAddressCommandResponse(validation);
            }
            company.Address.ApartmentNumber = request.ApartmentNumber;
            company.Address.City = request.City;
            company.Address.Street = request.Street;
            company.Address.HouseNumber = request.HouseNumber;
            company.Name = request.CompanyName;

            await companyRepository.UpdateAsync(company);
            return new UpdateCompanyWithAddressCommandResponse();
        }
    }
}
