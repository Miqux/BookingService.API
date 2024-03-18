namespace BookingService.Application.UseCase.Service.Queries.GetServicesLightModel
{
    public class GetServicesLightModelQuery : IRequest<List<ServiceLightViewModel>>
    {
        public ServiceType Type { get; set; } = new();
        public string? City { get; set; }
    }
}
