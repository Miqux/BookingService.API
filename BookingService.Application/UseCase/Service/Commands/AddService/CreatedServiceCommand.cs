using MediatR;
using static BookingService.Domain.Entities.Enums;

namespace BookingService.Application.UseCase.Service.Commands.AddService
{
    public class CreatedServiceCommand : IRequest<CreatedServiceCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int DurationInMinutes { get; set; }
        public int CompanyId { get; set; }
        public ServiceType Type { get; set; }
    }
}
