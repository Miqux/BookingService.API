using AutoMapper;
using BookingService.Application.Contracts.Calendary;
using BookingService.Application.Contracts.Persistance;
using BookingService.Domain.ValueObject;
using MediatR;

namespace BookingService.Application.UseCase.Service.Queries.GetPossibleServiceHours
{
    public class GetPossibleServiceHoursHandler : IRequestHandler<GetPossibleServiceHoursQuery, List<PossibleServiceHourViewModel>>
    {
        private readonly IGoogleCalendaryRepository googleCalendaryRepository;
        private readonly IServiceRepository serviceRepository;
        private readonly IMapper mapper;

        public GetPossibleServiceHoursHandler(IGoogleCalendaryRepository googleCalendaryRepository, IServiceRepository serviceRepository,
            IMapper mapper)
        {
            this.googleCalendaryRepository = googleCalendaryRepository;
            this.serviceRepository = serviceRepository;
            this.mapper = mapper;
        }
        public async Task<List<PossibleServiceHourViewModel>> Handle(GetPossibleServiceHoursQuery request, CancellationToken cancellationToken)
        {
            var service = await serviceRepository.GetWithChildren(request.ServiceId, true);
            if (service is null || service.Company is null || service.Company.Calendar is null)
                return new List<PossibleServiceHourViewModel>();

            var workingTime = await googleCalendaryRepository.GetWorkingHoursByDateAndCalendarId(request.DateOnly, service.Company.Calendar.Id);

            if (workingTime is null || workingTime.Count < 1)
                return new List<PossibleServiceHourViewModel>();

            var busyTime = await googleCalendaryRepository.GetBusyHoursByDateAndCalendarId(request.DateOnly, service.Company.Calendar.Id);

            if (busyTime is null)
                return new List<PossibleServiceHourViewModel>();

            List<ServiceTime> serviceTimes = new();

            foreach (var item in workingTime)
            {
                int numberOfParts = (int)((item.EndTime - item.StartTime).TotalMinutes / service.DurationInMinutes);

                for (int i = 0; i < numberOfParts; i++)
                {
                    TimeSpan partStartTime = item.StartTime.Add(TimeSpan.FromMinutes(i * service.DurationInMinutes));
                    TimeSpan partEndTime = partStartTime.Add(TimeSpan.FromMinutes(service.DurationInMinutes));
                    serviceTimes.Add(new ServiceTime { StartTime = partStartTime, EndTime = partEndTime });
                }
            }

            if (serviceTimes.Count < 1)
                return new List<PossibleServiceHourViewModel>();

            var freeTimes = new List<ServiceTime>();

            foreach (var serviceTime in serviceTimes)
            {
                bool isFree = !busyTime.Any(busyTime =>
                    serviceTime.StartTime < busyTime.EndTime && serviceTime.EndTime > busyTime.StartTime);

                if (isFree)
                {
                    freeTimes.Add(serviceTime);
                }
            }

            return mapper.Map<List<PossibleServiceHourViewModel>>(freeTimes);
        }
    }
}
