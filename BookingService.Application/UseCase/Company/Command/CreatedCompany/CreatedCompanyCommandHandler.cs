using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using FluentValidation.Results;
using MediatR;

namespace BookingService.Application.UseCase.Company.Command.CreatedCompany
{
    public class CreatedCompanyCommandHandler : IRequestHandler<CreatedCompanyCommand, CreatedCompanyCommandResponse>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public CreatedCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper, IUserRepository userRepository)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
        public async Task<CreatedCompanyCommandResponse> Handle(CreatedCompanyCommand request, CancellationToken cancellationToken)
        {
            var validator = await new CreatedCompanyCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validator.IsValid)
                return new CreatedCompanyCommandResponse(validator);

            var user = await userRepository.GetByIdAsync(request.UserId);

            if (user is null || user.Role is not Domain.Entities.Enums.UserRole.CompanyBoss)
                return new CreatedCompanyCommandResponse(new ValidationResult(new List<ValidationFailure>
                {
                    new ValidationFailure("UserId", "Incorrect User")
                }));

            if (await companyRepository.GetByName(request.Name) is not null)
                return new CreatedCompanyCommandResponse(new ValidationResult(new List<ValidationFailure>
                {
                    new ValidationFailure("Name", "Company with the same name already exist")
                }));

            Domain.Entities.Company company = new()
            {
                Name = request.Name,
                Address = mapper.Map<Domain.Entities.Address>(request),
                Calendar = mapper.Map<Domain.Entities.Calendar>(request),
                CompanyBoss = user
            };

            var addedCompany = await companyRepository.AddAsync(company);

            return new CreatedCompanyCommandResponse(addedCompany.Id);
        }
    }
}
