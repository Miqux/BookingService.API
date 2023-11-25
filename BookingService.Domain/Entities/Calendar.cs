namespace BookingService.Domain.Entities
{
    public class Calendar
    {
        public int Id { get; set; }
        public string ConfigurationJson { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
