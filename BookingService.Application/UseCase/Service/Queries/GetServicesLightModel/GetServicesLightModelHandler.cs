using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using MediatR;

namespace BookingService.Application.UseCase.Service.Queries.GetServicesLightModel
{
    public class GetServicesLightModelHandler : IRequestHandler<GetServicesLightModelQuery, List<ServiceLightModel>>
    {
        private readonly IServiceRepository serviceRepository;
        private readonly IMapper mapper;

        public GetServicesLightModelHandler(IServiceRepository serviceRepository, IMapper mapper)
        {
            this.serviceRepository = serviceRepository;
            this.mapper = mapper;
        }
        public async Task<List<ServiceLightModel>> Handle(GetServicesLightModelQuery request, CancellationToken cancellationToken)
        {
            var services = await serviceRepository.GetAllAsync();
            return mapper.Map<List<ServiceLightModel>>(services);
        }
    }
}
