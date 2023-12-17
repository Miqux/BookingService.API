using static BookingService.Domain.Entities.Enums;

namespace BookingService.Application.UseCase.User.Queries.GetUsersAdministration
{
    public class UserAdministrationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
