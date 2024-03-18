using BookingService.Application.Contracts.Persistance;

namespace BookingService.Application.UseCase.Company.Queries.GetCompanyByUserId
{
    public class GetCompanyByUserIdHandler : IRequestHandler<GetCompanyByUserIdQuery, CompanyByUserIdViewModel>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;

        public GetCompanyByUserIdHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }
        public async Task<CompanyByUserIdViewModel> Handle(GetCompanyByUserIdQuery request, CancellationToken cancellationToken)
        {
            var company = await companyRepository.GetByUserId(request.UserId);
            return mapper.Map<CompanyByUserIdViewModel>(company);
        }
    }
}
