using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using FluentValidation.Results;
using MediatR;

namespace BookingService.Application.UseCase.Service.Commands.AddService
{
    public class CreatedServiceCommandHandler : IRequestHandler<CreatedServiceCommand, CreatedServiceCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IServiceRepository serviceRepository;
        private readonly ICompanyRepository companyRepository;

        public CreatedServiceCommandHandler(IMapper mapper, IServiceRepository serviceRepository, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.serviceRepository = serviceRepository;
            this.companyRepository = companyRepository;
        }
        public async Task<CreatedServiceCommandResponse> Handle(CreatedServiceCommand request, CancellationToken cancellationToken)
        {
            var validator = await new CreatedServiceCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validator.IsValid)
                return new CreatedServiceCommandResponse(validator);

            var company = companyRepository.GetByIdAsync(request.CompanyId).Result;

            if (company is null)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("CompanyId", "Comapny doasn't exist"));
                return new CreatedServiceCommandResponse(validation);
            }

            var service = mapper.Map<Domain.Entities.Service>(request);
            service.Company = company;
            service.Active = true;

            service = await serviceRepository.AddAsync(service);

            return new CreatedServiceCommandResponse(service.Id);
        }
    }
}
