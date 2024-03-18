namespace BookingService.Application.UseCase.Service.Commands.CreateService
{
    public class CreateServiceCommand : IRequest<CreateServiceCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int DurationInMinutes { get; set; }
        public int CompanyId { get; set; }
        public ServiceType Type { get; set; }
    }
}
