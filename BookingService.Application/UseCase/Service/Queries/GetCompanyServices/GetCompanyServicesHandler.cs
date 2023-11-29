using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using MediatR;

namespace BookingService.Application.UseCase.Service.Queries.GetCompanyServices
{
    public class GetCompanyServicesHandler : IRequestHandler<GetCompanyServicesQuery, List<CompanyServiceViewModel>>
    {
        private readonly IMapper mapper;
        private readonly IServiceRepository serviceRepository;

        public GetCompanyServicesHandler(IMapper mapper, IServiceRepository serviceRepository)
        {
            this.mapper = mapper;
            this.serviceRepository = serviceRepository;
        }
        public async Task<List<CompanyServiceViewModel>> Handle(GetCompanyServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await serviceRepository.GetServicesByCompanyId(request.CompanyId);
            return mapper.Map<List<CompanyServiceViewModel>>(services);
        }
    }
}
