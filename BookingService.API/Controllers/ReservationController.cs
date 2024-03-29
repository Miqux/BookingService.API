﻿using BookingService.Application.UseCase.Reservation.Commands.CreateReservation;
using BookingService.Application.UseCase.Reservation.Commands.DeleteReservation;
using BookingService.Application.UseCase.Reservation.Queries.GetCompletedReservations;
using BookingService.Application.UseCase.Reservation.Queries.GetIncomingReservations;

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
        public async Task<ActionResult<CreateReservationCommandResponse>> Create([FromBody] CreateReservationCommand reservation)
        {
            var response = await mediator.Send(reservation);

            if (!response.Success && response.ValidationErrors.Count > 0)
                return UnprocessableEntity(response);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetIncomingReservationsByUserId/{id}")]
        public async Task<ActionResult<List<IncomingReservationViewModel>>> GetIncomingReservationsByUserId(int id)
        {
            var response = await mediator.Send(new GetIncomingReservationsQuery() { UserId = id });

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("GetCompletedReservationsByUserId/{id}")]
        public async Task<ActionResult<List<CompletedReservationViewModel>>> GetCompletedReservationsByUserId(int id)
        {
            var response = await mediator.Send(new GetCompletedReservationsQuery() { UserId = id });

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> Delete(int id)
        {
            var response = await mediator.Send(new DeleteReservationCommand() { Id = id });

            if (response.Status is ResponseStatus.NotFound)
                return NotFound(response);

            return Ok(response);
        }
    }
}
