using BookingService.Application.UseCase.User.Commands.CreateUser;
using BookingService.Application.UseCase.User.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<LoginCommandResponse>> Login([FromBody] LoginCommand loginCommand)
        {
            var response = await mediator.Send(loginCommand);
            return Ok(response);
        }
        [HttpPost("Registery")]
        public async Task<ActionResult<LoginCommandResponse>> Registery([FromBody] RegisteryCommand registeryCommand)
        {
            var response = await mediator.Send(registeryCommand);
            if (!response.Success && response.ValidationErrors.Count > 0)
                return UnprocessableEntity(response);

            return Ok(response);
        }
    }
}
