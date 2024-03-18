using BookingService.Application.Common;
using BookingService.Application.Contracts.Persistance;

namespace BookingService.Application.UseCase.Service.Commands.DeleteService
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, BaseResponse>
    {
        private readonly IServiceRepository serviceRepository;

        public DeleteServiceCommandHandler(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }
        public async Task<BaseResponse> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceToRemove = await serviceRepository.GetByIdAsync(request.ServiceId);

            if (serviceToRemove is null)
                return new BaseResponse("Brak usługi", false) { Status = Common.ResponseStatus.NotFound };

            serviceToRemove.Active = false;

            await serviceRepository.UpdateAsync(serviceToRemove);

            return new BaseResponse("Usunięto", true);
        }
    }
}
