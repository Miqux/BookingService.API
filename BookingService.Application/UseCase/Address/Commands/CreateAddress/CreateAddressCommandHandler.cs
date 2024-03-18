using BookingService.Application.Contracts.Persistance;

namespace BookingService.Application.UseCase.Address.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreatedAddressCommandResponse>
    {
        private readonly IAddressRepository addressRepository;
        private readonly IMapper mapper;

        public CreateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            this.addressRepository = addressRepository;
            this.mapper = mapper;
        }
        public async Task<CreatedAddressCommandResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = await new CreateAddressCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validator.IsValid)
                return new CreatedAddressCommandResponse(validator);

            var address = mapper.Map<Domain.Entities.Address>(request);

            address = await addressRepository.AddAsync(address);

            return new CreatedAddressCommandResponse(address.Id);
        }
    }
}
