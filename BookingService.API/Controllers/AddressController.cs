using BookingService.Application.UseCase.Address.Commands.CreateAddress;
using BookingService.Application.UseCase.Address.Queries.GetAddress;
using BookingService.Application.UseCase.Address.Queries.GetAllAddress;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressViewModel>> Get(int id)
        {
            var response = await mediator.Send(new GetAddressQuery() { Id = id });
            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<List<AddressInListViewModel>>> GetAll()
        {
            var response = await mediator.Send(new GetAddressListQuery());
            return Ok(response);
        }
    }
}
