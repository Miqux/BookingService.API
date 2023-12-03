namespace BookingService.Domain.ValueObject
{
    public class ServiceEvent
    {
        public string ServiceName { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string ClientSurname { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CalendarId { get; set; }
    }
}
