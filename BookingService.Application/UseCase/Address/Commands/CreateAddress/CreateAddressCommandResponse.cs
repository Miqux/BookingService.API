using BookingService.Application.Common;

namespace BookingService.Application.UseCase.Address.Commands.CreateAddress
{
    public class CreatedAddressCommandResponse : BaseResponse
    {
        public int? AddressId { get; set; }
        public CreatedAddressCommandResponse() : base()
        { }

        public CreatedAddressCommandResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public CreatedAddressCommandResponse(string message)
        : base(message)
        { }

        public CreatedAddressCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public CreatedAddressCommandResponse(int addressId)
        {
            AddressId = addressId;
        }
    }
}
