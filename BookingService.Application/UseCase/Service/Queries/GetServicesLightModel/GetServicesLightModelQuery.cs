using MediatR;

namespace BookingService.Application.UseCase.Service.Queries.GetServicesLightModel
{
    public class GetServicesLightModelQuery : IRequest<List<ServiceLightModel>>
    {
    }
}
