using MediatR;
using static BookingService.Domain.Entities.Enums;

namespace BookingService.Application.UseCase.Service.Commands
{
    public class CreatedServiceCommand : IRequest<CreatedServiceCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int DurationInMinutes { get; set; }
        public int ComapnyId { get; set; }
        public int EmployeeId { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
