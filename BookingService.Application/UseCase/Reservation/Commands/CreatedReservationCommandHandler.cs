using BookingService.Application.Contracts.Calendary;
using MediatR;

namespace BookingService.Application.UseCase.Reservation.Commands
{
    public class CreatedReservationCommandHandler : IRequestHandler<CreatedReservationCommand, CreatedReservationCommandResponse>
    {
        private readonly IGoogleCalendaryRepository calendaryRepository;

        public CreatedReservationCommandHandler(IGoogleCalendaryRepository calendaryRepository)
        {
            this.calendaryRepository = calendaryRepository;
        }
        public async Task<CreatedReservationCommandResponse> Handle(CreatedReservationCommand request, CancellationToken cancellationToken)
        {
            var result = await calendaryRepository.AddReservation(request);

            if (!result)
                return new CreatedReservationCommandResponse("niepowodzenie", false);

            return new CreatedReservationCommandResponse();
        }
    }
}
