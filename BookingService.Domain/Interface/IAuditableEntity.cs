namespace BookingService.Domain.Interface
{
    public interface IAuditableEntity : IEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        string LastModifiedBy { get; set; }
        DateTime? LastModifiedDate { get; set; }
    }
}
