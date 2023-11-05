namespace BookingService.Persistence
{
    public static class GeneratorHelper
    {
        private static readonly Random random = new();

        public static DateTime GenerateRandomDate(DateTime startDate, DateTime endDate)
        {
            if (startDate >= endDate)
                return DateTime.Now;

            TimeSpan timeSpan = endDate - startDate;
            int totalDays = random.Next(0, (int)timeSpan.TotalDays);
            return startDate.AddDays(totalDays).AddHours(random.Next(0, 24)).AddMinutes(random.Next(0, 60)).AddSeconds(random.Next(0, 60));
        }
    }
}
