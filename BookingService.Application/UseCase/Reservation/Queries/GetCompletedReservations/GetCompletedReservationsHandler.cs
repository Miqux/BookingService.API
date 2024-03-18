using BookingService.Application.Contracts.Persistance;

namespace BookingService.Application.UseCase.Reservation.Queries.GetCompletedReservations
{
    public class GetCompletedReservationsHandler : IRequestHandler<GetCompletedReservationsQuery, List<CompletedReservationViewModel>>
    {
        private readonly IReservationRepository reservationRepository;
        private readonly IMapper mapper;

        public GetCompletedReservationsHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            this.reservationRepository = reservationRepository;
            this.mapper = mapper;
        }
        public async Task<List<CompletedReservationViewModel>> Handle(GetCompletedReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await reservationRepository.GetCompletedWithChildrenByUserId(request.UserId);
            return mapper.Map<List<CompletedReservationViewModel>>(reservations);
        }
    }
}
