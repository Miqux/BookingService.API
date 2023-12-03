using MediatR;

namespace BookingService.Application.UseCase.Service.Queries.GetPossibleServiceHours
{
    public class GetPossibleServiceHoursQuery : IRequest<List<PossibleServiceHourViewModel>>
    {
        public int ServiceId { get; set; }
        public DateOnly DateOnly { get; set; }
    }
}
