using BookingService.Application.Contracts.Calendary;
using BookingService.Application.Contracts.Persistance;
using BookingService.Domain.ValueObject;
using FluentValidation.Results;
using MediatR;

namespace BookingService.Application.UseCase.Reservation.Commands
{
    public class CreatedReservationCommandHandler : IRequestHandler<CreatedReservationCommand, CreatedReservationCommandResponse>
    {
        private readonly IGoogleCalendaryRepository googleCalendaryRepository;
        private readonly ICalendarRepository calendarRepository;
        private readonly IUserRepository userRepository;
        private readonly IServiceRepository serviceRepository;
        private readonly IReservationRepository reservationRepository;

        public CreatedReservationCommandHandler(IGoogleCalendaryRepository googleCalendaryRepository, ICalendarRepository calendarRepository
            , IUserRepository userRepository, IServiceRepository serviceRepository, IReservationRepository reservationRepository)
        {
            this.googleCalendaryRepository = googleCalendaryRepository;
            this.calendarRepository = calendarRepository;
            this.userRepository = userRepository;
            this.serviceRepository = serviceRepository;
            this.reservationRepository = reservationRepository;
        }
        public async Task<CreatedReservationCommandResponse> Handle(CreatedReservationCommand request, CancellationToken cancellationToken)
        {
            var validator = await new CreatedReservationCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validator.IsValid)
                return new CreatedReservationCommandResponse(validator);

            var user = await userRepository.GetByIdAsync(request.UserId);

            if (user is null)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("UserId", "user doasn't exist"));
                return new CreatedReservationCommandResponse(validation);
            }

            var service = await serviceRepository.GetWithChildren(request.ServiceId, true);

            if (service is null || !service.Active)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("ServiceId", "Service doasn't exist"));
                return new CreatedReservationCommandResponse(validation);
            }

            if (service.Company.Calendar is null)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("ComapnyCalendar", "Comapny calendar doasn't exist"));
                return new CreatedReservationCommandResponse(validation);
            }

            ServiceEvent serviceEvent = new()
            {
                ServiceName = service.Name,
                ClientName = user.Name,
                ClientSurname = user.LastName,
                StartDate = request.StartDateAndTime,
                EndDate = request.EndDateAndTime,
                CalendarId = service.Company.Calendar.Id
            };

            var result = await googleCalendaryRepository.AddServiceEvent(serviceEvent);

            if (!result)
                return new CreatedReservationCommandResponse("Wrong google event", false);

            Domain.Entities.Reservation reservation = new()
            {
                Service = service,
                User = user,
                EndDate = serviceEvent.EndDate,
                StartDate = serviceEvent.StartDate
            };

            var createdReservation = await reservationRepository.AddAsync(reservation);

            return new CreatedReservationCommandResponse(createdReservation.Id);
        }
    }
}
