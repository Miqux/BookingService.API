using BookingService.Application.Contracts.Persistance;

namespace BookingService.Application.UseCase.Reservation.Queries.GetIncomingReservations
{
    public class GetIncomingReservationsHandler : IRequestHandler<GetIncomingReservationsQuery, List<IncomingReservationViewModel>>
    {
        private readonly IReservationRepository reservationRepository;
        private readonly IMapper mapper;

        public GetIncomingReservationsHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            this.reservationRepository = reservationRepository;
            this.mapper = mapper;
        }
        public async Task<List<IncomingReservationViewModel>> Handle(GetIncomingReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await reservationRepository.GetIncomingWithChildrenByUserId(request.UserId);
            return mapper.Map<List<IncomingReservationViewModel>>(reservations);
        }
    }
}
