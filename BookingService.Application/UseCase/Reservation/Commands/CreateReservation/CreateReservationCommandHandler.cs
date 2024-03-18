using BookingService.Application.Contracts.Calendary;
using BookingService.Application.Contracts.Persistance;
using BookingService.Domain.ValueObject;
using FluentValidation.Results;
using MediatR;

namespace BookingService.Application.UseCase.Reservation.Commands.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, CreateReservationCommandResponse>
    {
        private readonly IGoogleCalendaryRepository googleCalendaryRepository;
        private readonly IUserRepository userRepository;
        private readonly IServiceRepository serviceRepository;
        private readonly IReservationRepository reservationRepository;

        public CreateReservationCommandHandler(IGoogleCalendaryRepository googleCalendaryRepository, IUserRepository userRepository,
            IServiceRepository serviceRepository, IReservationRepository reservationRepository)
        {
            this.googleCalendaryRepository = googleCalendaryRepository;
            this.userRepository = userRepository;
            this.serviceRepository = serviceRepository;
            this.reservationRepository = reservationRepository;
        }
        public async Task<CreateReservationCommandResponse> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var validator = await new CreateReservationCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validator.IsValid)
                return new CreateReservationCommandResponse(validator);

            var user = await userRepository.GetByIdAsync(request.UserId);

            if (user is null)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("UserId", "user doasn't exist"));
                return new CreateReservationCommandResponse(validation);
            }

            var service = await serviceRepository.GetWithChildren(request.ServiceId, true);

            if (service is null || !service.Active)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("ServiceId", "Service doasn't exist"));
                return new CreateReservationCommandResponse(validation);
            }

            if (service.Company.Calendar is null)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("ComapnyCalendar", "Comapny calendar doasn't exist"));
                return new CreateReservationCommandResponse(validation);
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

            var checkAvailable = await googleCalendaryRepository.CheckDateTimeIsAvailable(serviceEvent);

            if (!checkAvailable)
                return new CreateReservationCommandResponse("Reservation date is available", false);

            var result = await googleCalendaryRepository.AddServiceEvent(serviceEvent);

            if (!result)
                return new CreateReservationCommandResponse("Wrong google event", false);

            Domain.Entities.Reservation reservation = new()
            {
                Service = service,
                User = user,
                EndDate = serviceEvent.EndDate,
                StartDate = serviceEvent.StartDate
            };

            var createdReservation = await reservationRepository.AddAsync(reservation);

            return new CreateReservationCommandResponse(createdReservation.Id);
        }
    }
}
