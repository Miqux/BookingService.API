using BookingService.Application.Common;
using BookingService.Application.Contracts.Calendary;
using BookingService.Application.Contracts.Persistance;
using FluentValidation.Results;
using MediatR;

namespace BookingService.Application.UseCase.Reservation.Commands.DeleteReservation
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, BaseResponse>
    {
        private readonly IGoogleCalendaryRepository googleCalendaryRepository;
        private readonly IReservationRepository reservationRepository;
        private readonly IServiceRepository serviceRepository;

        public DeleteReservationCommandHandler(IGoogleCalendaryRepository googleCalendaryRepository,
            IReservationRepository reservationRepository, IServiceRepository serviceRepository)
        {
            this.googleCalendaryRepository = googleCalendaryRepository;
            this.reservationRepository = reservationRepository;
            this.serviceRepository = serviceRepository;
        }
        public async Task<BaseResponse> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var validator = await new DeleteReservationCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validator.IsValid)
                return new BaseResponse(validator);

            var reservation = await reservationRepository.GetByIdWithChildren(request.Id);

            if (reservation is null || reservation.Service is null)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("ReservationId", "Reservation doasn't exist"));
                return new BaseResponse(validation) { Status = Common.ResponseStatus.NotFound };
            }

            var service = await serviceRepository.GetWithChildren(reservation.Service.Id, true);

            if (service is null)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("ServiceId", "Service doasn't exist"));
                return new BaseResponse(validation) { Status = Common.ResponseStatus.NotFound };
            }

            if (service.Company.Calendar is null)
            {
                ValidationResult validation = new(new List<ValidationFailure>());
                validation.Errors.Add(new ValidationFailure("ComapnyCalendar", "Comapny calendar doasn't exist"));
                return new BaseResponse(validation) { Status = Common.ResponseStatus.NotFound };
            }

            var googleCalendarResult = await googleCalendaryRepository.DeleteEvent(reservation.StartDate, reservation.EndDate, service.Company.Calendar.Id);

            if (!googleCalendarResult)
                return new BaseResponse("Error in deleting in google calendar");

            await reservationRepository.DeleteAsync(reservation);
            return new BaseResponse();
        }
    }
}
