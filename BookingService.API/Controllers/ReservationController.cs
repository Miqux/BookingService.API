using BookingService.Application.UseCase.Reservation.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReservationController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<CreatedReservationCommandResponse>> Create([FromBody] CreatedReservationCommand reservation)
        {
            var response = await mediator.Send(reservation);

            if (!response.Success && response.ValidationErrors.Count > 0)
                return UnprocessableEntity(response);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
