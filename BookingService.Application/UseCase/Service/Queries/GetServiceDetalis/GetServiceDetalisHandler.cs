using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using MediatR;

namespace BookingService.Application.UseCase.Service.Queries.GetServiceDetalis
{
    public class GetServiceDetalisHandler : IRequestHandler<GetServiceDetalisQuery, ServiceDetalisViewModel>
    {
        private readonly IMapper mapper;
        private readonly IServiceRepository serviceRepository;

        public GetServiceDetalisHandler(IMapper mapper, IServiceRepository serviceRepository)
        {
            this.mapper = mapper;
            this.serviceRepository = serviceRepository;
        }
        public async Task<ServiceDetalisViewModel> Handle(GetServiceDetalisQuery request, CancellationToken cancellationToken)
        {
            var serviceDetails = await serviceRepository.GetServiceDetalis(request.Id);
            return mapper.Map<ServiceDetalisViewModel>(serviceDetails);
        }
    }
}
