using BookingService.Application.Contracts.Persistance;

namespace BookingService.Application.UseCase.Service.Queries.GetAllServices
{
    public class GetServicesListHandler : IRequestHandler<GetServicesListQuery, List<ServiceInListViewModel>>
    {
        private readonly IMapper mapper;
        private readonly IServiceRepository serviceRepository;

        public GetServicesListHandler(IMapper mapper, IServiceRepository serviceRepository)
        {
            this.mapper = mapper;
            this.serviceRepository = serviceRepository;
        }
        public async Task<List<ServiceInListViewModel>> Handle(GetServicesListQuery request, CancellationToken cancellationToken)
        {
            var services = await serviceRepository.GetAllAsync();
            return mapper.Map<List<ServiceInListViewModel>>(services);
        }
    }
}
