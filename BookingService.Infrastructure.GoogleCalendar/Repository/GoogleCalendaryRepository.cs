using BookingService.Application.Contracts.Calendary;
using BookingService.Application.Contracts.Persistance;
using BookingService.Domain.ValueObject;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

namespace BookingService.Infrastructure.GoogleCalendar.Repository
{
    public class GoogleCalendaryRepository : IGoogleCalendaryRepository
    {
        private string calendarName = string.Empty;
        private readonly ICalendarRepository calendarRepository;

        public GoogleCalendaryRepository(ICalendarRepository calendarRepository)
        {
            this.calendarRepository = calendarRepository;
        }
        private async Task<CalendarService?> CreateCalendarService(int calendarId)
        {
            string[] Scopes = { CalendarService.Scope.Calendar };
            ServiceAccountCredential credential;
            try
            {
                var calendar = await calendarRepository.GetByIdAsync(calendarId);

                if (calendar is null) return null;

                calendarName = calendar.Name;

                credential = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(calendar.Client_email)
                    {
                        Scopes = Scopes
                    }.FromPrivateKey(calendar.Private_key));

                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Rezerwator 2000",
                });
                return service;
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<ServiceTime>> GetWorkingHoursByDateAndCalendarId(DateOnly dateOnly, int calendarId)
        {
            List<ServiceTime> freeSlots = new();
            var service = await CreateCalendarService(calendarId);

            if (service is null)
                return freeSlots;

            EventsResource.ListRequest request = service.Events.List(calendarName);
            request.TimeMinDateTimeOffset = dateOnly.ToDateTime(new TimeOnly(00, 00, 00));
            request.TimeMaxDateTimeOffset = dateOnly.ToDateTime(new TimeOnly(23, 59, 59));
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            Events events = request.Execute();

            foreach (var item in events.Items)
            {
                if (item.Transparency == "transparent" && item.Start.DateTimeDateTimeOffset.HasValue && item.End.DateTimeDateTimeOffset.HasValue)
                {
                    TimeSpan freeSlotStart = item.Start.DateTimeDateTimeOffset.Value.TimeOfDay;
                    TimeSpan freeSlotEnd = item.End.DateTimeDateTimeOffset.Value.TimeOfDay;
                    ServiceTime serviceTime = new()
                    {
                        StartTime = freeSlotStart,
                        EndTime = freeSlotEnd
                    };
                    freeSlots.Add(serviceTime);
                }
            }
            return freeSlots;
        }
        public async Task<List<ServiceTime>> GetBusyHoursByDateAndCalendarId(DateOnly dateOnly, int calendarId)
        {
            List<ServiceTime> freeSlots = new();
            var service = await CreateCalendarService(calendarId);

            if (service is null)
                return freeSlots;

            EventsResource.ListRequest request = service.Events.List(calendarName);
            request.TimeMinDateTimeOffset = dateOnly.ToDateTime(new TimeOnly(00, 00, 00));
            request.TimeMaxDateTimeOffset = dateOnly.ToDateTime(new TimeOnly(23, 59, 59));
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            Events events = request.Execute();

            foreach (var item in events.Items)
            {
                if (item.Transparency != "transparent" && item.Start.DateTimeDateTimeOffset.HasValue && item.End.DateTimeDateTimeOffset.HasValue)
                {
                    TimeSpan freeSlotStart = item.Start.DateTimeDateTimeOffset.Value.TimeOfDay;
                    TimeSpan freeSlotEnd = item.End.DateTimeDateTimeOffset.Value.TimeOfDay;

                    ServiceTime serviceTime = new()
                    {
                        StartTime = freeSlotStart,
                        EndTime = freeSlotEnd
                    };
                    freeSlots.Add(serviceTime);
                }
            }
            return freeSlots;
        }
        public async Task<bool> AddServiceEvent(ServiceEvent serviceEvent)
        {
            var service = await CreateCalendarService(serviceEvent.CalendarId);

            if (service is null)
                return false;

            var myevent = new Event()
            {
                Summary = serviceEvent.ServiceName,
                Description = serviceEvent.ClientName + " " + serviceEvent.ClientSurname,
                Start = new EventDateTime() { DateTimeDateTimeOffset = serviceEvent.StartDate },
                End = new EventDateTime() { DateTimeDateTimeOffset = serviceEvent.EndDate }
            };

            var InsertRequest = service.Events.Insert(myevent, calendarName);

            try
            {
                InsertRequest.Execute();
            }
            catch (Exception)
            {
                try
                {
                    service.Events.Update(myevent, calendarName, myevent.Id).Execute();
                    Console.WriteLine("Insert/Update new Event ");
                    Console.Read();

                }
                catch (Exception x)
                {
                    await Console.Out.WriteLineAsync(x.ToString());
                    Console.WriteLine("can't Insert/Update new Event ");
                    return false;
                }
            }
            return true;
        }
        public async Task<bool> CheckDateTimeIsAvailable(ServiceEvent serviceEvent)
        {
            bool result;
            var service = await CreateCalendarService(serviceEvent.CalendarId);

            if (service is null)
                return false;

            EventsResource.ListRequest request = service.Events.List(calendarName);
            request.TimeMinDateTimeOffset = serviceEvent.StartDate;
            request.TimeMaxDateTimeOffset = serviceEvent.EndDate;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            Events events = request.Execute();

            if (events.Items.Count > 1)
                return false;

            result = events.Items.Any(x => x.Transparency == "transparent");

            return result;
        }
        public async Task<bool> DeleteEvent(DateTime startDate, DateTime endDate, int calendarId)
        {
            var service = await CreateCalendarService(calendarId);

            if (service is null)
                return false;

            EventsResource.ListRequest request = service.Events.List(calendarName);
            request.TimeMinDateTimeOffset = startDate;
            request.TimeMaxDateTimeOffset = endDate;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            Events events = request.Execute();

            if (events is null || events.Items is null)
                return false;

            Event? eventToDelete = events.Items.FirstOrDefault(x => x.Transparency != "transparent");

            if (eventToDelete is null)
                return false;

            service.Events.Delete(calendarName, eventToDelete.Id).Execute();
            return true;
        }
    }
}
