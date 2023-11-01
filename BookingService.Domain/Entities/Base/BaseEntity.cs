using BookingService.Domain.Interface;

namespace BookingService.Domain.Entities.Base
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
