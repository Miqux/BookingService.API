using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using MediatR;

namespace BookingService.Application.UseCase.Service.Commands
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

            var company = companyRepository.GetByIdAsync(request.ComapnyId).Result;

            if (company == null)
                return new CreatedServiceCommandResponse("Comapny doasn't exist", false);

            var service = mapper.Map<Domain.Entities.Service>(request);
            service.Company = company;

            service = await serviceRepository.AddAsync(service);

            return new CreatedServiceCommandResponse(service.Id);
        }
    }
}
