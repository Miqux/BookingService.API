using BookingService.Application.Common;
using BookingService.Application.UseCase.User.Commands.CreateUser;
using BookingService.Application.UseCase.User.Commands.Login;
using BookingService.Application.UseCase.User.Commands.UpdateUserRole;
using BookingService.Application.UseCase.User.Queries.GetUser;
using BookingService.Application.UseCase.User.Queries.GetUsersAdministration;
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

        [HttpPost]
        public async Task<ActionResult<LoginCommandResponse>> Registery([FromBody] RegisteryCommand registeryCommand)
        {
            var response = await mediator.Send(registeryCommand);
            if (!response.Success && response.ValidationErrors.Count > 0)
                return UnprocessableEntity(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> Get(int id)
        {
            var response = await mediator.Send(new GetUserQuery() { Id = id });

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("GetUserAdministration")]
        public async Task<ActionResult<UserAdministrationViewModel>> GetUserAdministration()
        {
            var response = await mediator.Send(new GetUsersAdministrationQuery());

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpPut("UpdateUserRole")]
        public async Task<ActionResult<BaseResponse>> UpdateUserRole(UpdateUserRoleCommand user)
        {
            var response = await mediator.Send(user);
            if (!response.Success && response.ValidationErrors.Count > 0)
                return UnprocessableEntity(response);

            return Ok(response);
        }
    }
}
