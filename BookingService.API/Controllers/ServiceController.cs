using BookingService.Application.UseCase.Service.Commands;
using BookingService.Application.UseCase.Service.Queries.GetAllServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator mediator;

        public ServiceController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<CreatedServiceCommandResponse>> Create([FromBody] CreatedServiceCommand service)
        {
            var response = await mediator.Send(service);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ServiceInListViewModel>>> Get()
        {
            var response = await mediator.Send(new GetServicesListQuery());
            return Ok(response);
        }
    }
}
