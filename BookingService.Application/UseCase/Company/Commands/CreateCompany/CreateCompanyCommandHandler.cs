using BookingService.Application.Contracts.Persistance;

namespace BookingService.Application.UseCase.Company.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyCommandResponse>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper, IUserRepository userRepository)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var validator = await new CreateCompanyCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validator.IsValid)
                return new CreateCompanyCommandResponse(validator);

            var user = await userRepository.GetByIdAsync(request.UserId);

            if (user is null || user.Role is not UserRole.CompanyBoss)
                return new CreateCompanyCommandResponse(new ValidationResult(new List<ValidationFailure>
                {
                    new ValidationFailure("UserId", "Incorrect User")
                }));

            if (await companyRepository.GetByName(request.Name) is not null)
                return new CreateCompanyCommandResponse(new ValidationResult(new List<ValidationFailure>
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

            return new CreateCompanyCommandResponse(addedCompany.Id);
        }
    }
}
