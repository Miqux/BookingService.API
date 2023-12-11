using static BookingService.Domain.Entities.Enums;

namespace BookingService.Application.UseCase.Reservation.Queries.GetCompletedReservations
{
    public class CompletedReservationViewModel
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public ServiceType ServiceType { get; set; }
        public decimal ServiceCost { get; set; }
        public int ServiceDurationInMinutes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
