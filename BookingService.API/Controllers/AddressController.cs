using BookingService.Application.UseCase.Address.Commands.CreateAddress;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator mediator;

        public AddressController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<CreatedAddressCommandResponse>> Create([FromBody] CreatedAddressCommand createdAddressCommand)
        {
            var response = await mediator.Send(createdAddressCommand);
            return Ok(response);
        }
    }
}
