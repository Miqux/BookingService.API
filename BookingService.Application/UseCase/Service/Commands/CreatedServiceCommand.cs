using MediatR;

namespace BookingService.Application.UseCase.Service.Commands
{
    public class CreatedServiceCommand : IRequest<CreatedServiceCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int DurationInMinutes { get; set; }
        public int ComapnyId { get; set; }
        public int EmployeeId { get; set; }
    }
}
