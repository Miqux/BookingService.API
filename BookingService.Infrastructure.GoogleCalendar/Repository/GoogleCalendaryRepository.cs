using BookingService.Application.Contracts.Calendary;
using BookingService.Application.Contracts.Persistance;
using BookingService.Application.UseCase.Reservation.Commands;
using BookingService.Domain.ValueObject;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

#nullable disable

namespace BookingService.Infrastructure.GoogleCalendar.Repository
{
    public class GoogleCalendaryRepository : IGoogleCalendaryRepository
    {
        private string calendarName;
        private readonly ICalendarRepository calendarRepository;

        public GoogleCalendaryRepository(ICalendarRepository calendarRepository)
        {
            this.calendarRepository = calendarRepository;
        }
        private async Task<CalendarService> CreateCalendarService(int calendarId)
        {
            string[] Scopes = { CalendarService.Scope.Calendar };
            ServiceAccountCredential credential;
            try
            {
                var calendar = await calendarRepository.GetByIdAsync(calendarId);
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
            catch (Exception ex)
            {
                var temp = ex;
            }

            return null;

        }
        public async Task<List<ServiceTime>> GetWorkingHoursByDateAndCalendarId(DateOnly dateOnly, int calendarId)
        {
            var service = await CreateCalendarService(calendarId);
            EventsResource.ListRequest request = service.Events.List(calendarName);
            request.TimeMin = dateOnly.ToDateTime(new TimeOnly(00, 00, 00));
            request.TimeMax = dateOnly.ToDateTime(new TimeOnly(23, 59, 59));
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // Wysyłanie zapytania i pobieranie odpowiedzi
            Events events = request.Execute();

            // Przetwarzanie odpowiedzi, aby uzyskać wolne godziny
            List<ServiceTime> freeSlots = new List<ServiceTime>();

            foreach (var item in events.Items)
            {
                // Sprawdzenie, czy to jest wydarzenie typu "wolne"
                if (item.Transparency == "transparent" && item.Start.DateTime.HasValue && item.End.DateTime.HasValue)
                {
                    TimeSpan freeSlotStart = item.Start.DateTime.Value.TimeOfDay;
                    TimeSpan freeSlotEnd = item.End.DateTime.Value.TimeOfDay;

                    ServiceTime serviceTime = new ServiceTime();
                    serviceTime.StartTime = freeSlotStart;
                    serviceTime.EndTime = freeSlotEnd;
                    freeSlots.Add(serviceTime);
                }
            }
            return freeSlots;
        }
        public async Task<List<ServiceTime>> GetBusyHoursByDateAndCalendarId(DateOnly dateOnly, int calendarId)
        {
            var service = await CreateCalendarService(calendarId);
            EventsResource.ListRequest request = service.Events.List(calendarName);
            request.TimeMin = dateOnly.ToDateTime(new TimeOnly(00, 00, 00));
            request.TimeMax = dateOnly.ToDateTime(new TimeOnly(23, 59, 59));
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // Wysyłanie zapytania i pobieranie odpowiedzi
            Events events = request.Execute();

            // Przetwarzanie odpowiedzi, aby uzyskać wolne godziny
            List<ServiceTime> freeSlots = new List<ServiceTime>();

            foreach (var item in events.Items)
            {
                // Sprawdzenie, czy to jest wydarzenie typu "wolne"
                if (item.Transparency != "transparent" && item.Start.DateTime.HasValue && item.End.DateTime.HasValue)
                {
                    TimeSpan freeSlotStart = item.Start.DateTime.Value.TimeOfDay;
                    TimeSpan freeSlotEnd = item.End.DateTime.Value.TimeOfDay;

                    ServiceTime serviceTime = new ServiceTime();
                    serviceTime.StartTime = freeSlotStart;
                    serviceTime.EndTime = freeSlotEnd;
                    freeSlots.Add(serviceTime);
                }
            }
            return freeSlots;
        }
        public async Task<bool> AddReservation(CreatedReservationCommand reservation)
        {
            string calendarId = @"bartlomiejmikolajczuk@gmail.com";
            var service = await CreateCalendarService(1);
            var calendar = service.Calendars.Get(calendarId).Execute();
            Console.WriteLine("Calendar Name :");
            Console.WriteLine(calendar.Summary);

            Console.WriteLine("click for more .. ");
            Console.Read();


            // Define parameters of request.
            EventsResource.ListRequest listRequest = service.Events.List(calendarId);
            listRequest.TimeMin = DateTime.Now;
            listRequest.ShowDeleted = false;
            listRequest.SingleEvents = true;
            listRequest.MaxResults = 10;
            listRequest.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = listRequest.Execute();
            Console.WriteLine("Upcoming events:");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                }
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }
            Console.WriteLine("click for more .. ");
            Console.Read();

            var myevent = new Event()
            {
                Summary = "Test",
                Start = new EventDateTime() { DateTime = DateTime.Now },
                End = new EventDateTime() { DateTime = DateTime.Now.AddMinutes(60) }

            };

            var InsertRequest = service.Events.Insert(myevent, calendarId);

            try
            {
                InsertRequest.Execute();
            }
            catch (Exception)
            {
                try
                {
                    service.Events.Update(myevent, calendarId, myevent.Id).Execute();
                    Console.WriteLine("Insert/Update new Event ");
                    Console.Read();

                }
                catch (Exception x)
                {
                    await Console.Out.WriteLineAsync(x.ToString());
                    Console.WriteLine("can't Insert/Update new Event ");

                }
            }
            return true;
        }
    }
}
