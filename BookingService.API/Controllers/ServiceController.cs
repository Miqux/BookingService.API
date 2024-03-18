using BookingService.Application.UseCase.Service.Commands.CreateService;
using BookingService.Application.UseCase.Service.Commands.DeleteService;
using BookingService.Application.UseCase.Service.Queries.GetAllServices;
using BookingService.Application.UseCase.Service.Queries.GetCompanyServices;
using BookingService.Application.UseCase.Service.Queries.GetPossibleServiceHours;
using BookingService.Application.UseCase.Service.Queries.GetServiceDetalis;
using BookingService.Application.UseCase.Service.Queries.GetServicesLightModel;
using System.Globalization;

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
        public async Task<ActionResult<CreateServiceCommandResponse>> Create([FromBody] CreateServiceCommand service)
        {
            var response = await mediator.Send(service);

            if (!response.Success && response.ValidationErrors.Count > 0)
                return UnprocessableEntity(response);

            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<List<ServiceInListViewModel>>> Get()
        {
            var response = await mediator.Send(new GetServicesListQuery());
            return Ok(response);
        }
        [HttpGet("GetLightModels")]
        public async Task<ActionResult<List<ServiceLightViewModel>>> GetLight(ServiceType serviceType, string? city)
        {
            var response = await mediator.Send(new GetServicesLightModelQuery() { Type = serviceType, City = city });
            return Ok(response);
        }
        [HttpGet("GetCompanyServices/{id}")]
        public async Task<ActionResult<List<ServiceLightViewModel>>> GetCompanyServices(int id)
        {
            var response = await mediator.Send(new GetCompanyServicesQuery() { CompanyId = id });

            if (response is null || response.Count == 0)
                return NotFound();

            return Ok(response);
        }
        [HttpGet("GetServiceDetails/{id}")]
        public async Task<ActionResult<List<ServiceLightViewModel>>> GetServiceDetails(int id)
        {
            var response = await mediator.Send(new GetServiceDetalisQuery() { Id = id });

            if (response is null)
                return NotFound();

            return Ok(response);
        }
        [HttpGet("GetPossibleServiceHour/{id}/{date}")]
        public async Task<ActionResult<List<PossibleServiceHourViewModel>>> GetPossibleServiceHour(int id, string date)
        {
            bool dateParse = DateOnly.TryParseExact(date, "d.M.yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out DateOnly dateOnly);

            if (!dateParse)
                return BadRequest("Wrong dateOnly value");

            var response = await mediator.Send(new GetPossibleServiceHoursQuery() { ServiceId = id, DateOnly = dateOnly });

            if (response is null || response.Count < 1)
                return NotFound();

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> Delete(int id)
        {
            var response = await mediator.Send(new DeleteServiceCommand() { ServiceId = id });

            if (response.Status is ResponseStatus.NotFound)
                return NotFound(response);

            return Ok(response);
        }
    }
}
