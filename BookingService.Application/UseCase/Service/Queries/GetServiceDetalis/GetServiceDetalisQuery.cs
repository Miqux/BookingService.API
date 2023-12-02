using MediatR;

namespace BookingService.Application.UseCase.Service.Queries.GetServiceDetalis
{
    public class GetServiceDetalisQuery : IRequest<ServiceDetalisViewModel>
    {
        public int Id { get; set; }
    }
}
