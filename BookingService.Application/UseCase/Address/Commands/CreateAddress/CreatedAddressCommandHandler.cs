using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using MediatR;

namespace BookingService.Application.UseCase.Address.Commands.CreateAddress
{
    public class CreatedAddressCommandHandler : IRequestHandler<CreatedAddressCommand, CreatedAddressCommandResponse>
    {
        private readonly IAddressRepository addressRepository;
        private readonly IMapper mapper;

        public CreatedAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            this.addressRepository = addressRepository;
            this.mapper = mapper;
        }
        public async Task<CreatedAddressCommandResponse> Handle(CreatedAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = await new CreatedAddressCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validator.IsValid)
                return new CreatedAddressCommandResponse(validator);

            var address = mapper.Map<Domain.Entities.Address>(request);

            address = await addressRepository.AddAsync(address);

            return new CreatedAddressCommandResponse(address.Id);
        }
    }
}
