using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using FluentValidation.Results;
using MediatR;

namespace BookingService.Application.UseCase.Company.Command.UpdatedComapnyWithAddress
{
    public class UpdatedCompanyWithAddressCommandHandler : IRequestHandler<UpdatedCompanyWithAddressCommand, UpdatedCompanyWithAddressCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;

        public UpdatedCompanyWithAddressCommandHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }
        public async Task<UpdatedCompanyWithAddressCommandResponse> Handle(UpdatedCompanyWithAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = await new UpdatedCompanyWithAddressCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validator.IsValid)
                return new UpdatedCompanyWithAddressCommandResponse(validator);

            var company = await companyRepository.GetWithChildren(request.CompanyId);

            if (company is null)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("CompanyId", "Comapny doasn't exist"));
                return new UpdatedCompanyWithAddressCommandResponse(validation);
            }

            if (company.Address is null)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("Address", "Address doasn't exist"));
                return new UpdatedCompanyWithAddressCommandResponse(validation);
            }
            company.Address.ApartmentNumber = request.ApartmentNumber;
            company.Address.City = request.City;
            company.Address.Street = request.Street;
            company.Address.HouseNumber = request.HouseNumber;
            company.Name = request.CompanyName;

            await companyRepository.UpdateAsync(company);
            return new UpdatedCompanyWithAddressCommandResponse();
        }
    }
}
