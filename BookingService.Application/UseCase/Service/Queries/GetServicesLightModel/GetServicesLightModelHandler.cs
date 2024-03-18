using BookingService.Application.Contracts.Persistance;

namespace BookingService.Application.UseCase.Service.Queries.GetServicesLightModel
{
    public class GetServicesLightModelHandler : IRequestHandler<GetServicesLightModelQuery, List<ServiceLightViewModel>>
    {
        private readonly IServiceRepository serviceRepository;
        private readonly IMapper mapper;

        public GetServicesLightModelHandler(IServiceRepository serviceRepository, IMapper mapper)
        {
            this.serviceRepository = serviceRepository;
            this.mapper = mapper;
        }
        public async Task<List<ServiceLightViewModel>> Handle(GetServicesLightModelQuery request, CancellationToken cancellationToken)
        {
            ServiceType? serviceType = request.Type == 0 ? null : request.Type;
            string? city = request.City is null || request.City.Length == 0 ? null : request.City;
            var services = await serviceRepository.GetAllWithChildren(serviceType, city);
            return mapper.Map<List<ServiceLightViewModel>>(services);
        }
    }
}
