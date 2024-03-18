using BookingService.Application.UseCase.Company.Commands.CreateCompany;
using BookingService.Application.UseCase.Company.Commands.UpdateComapnyWithAddress;
using BookingService.Application.UseCase.Company.Queries.GetCompanyByUserId;

namespace BookingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator mediator;

        public CompanyController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("GetByUserId/{id}")]
        public async Task<ActionResult<CompanyByUserIdViewModel>> Get(int id)
        {
            var response = await mediator.Send(new GetCompanyByUserIdQuery() { UserId = id });

            if (response is null)
                return NotFound();

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<CreateCompanyCommandResponse>> Post([FromBody] CreateCompanyCommand createdCompany)
        {
            var response = await mediator.Send(createdCompany);
            if (!response.Success && response.ValidationErrors.Count > 0)
                return UnprocessableEntity(response);

            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<UpdateCompanyWithAddressCommandResponse>> Update(UpdateCompanyWithAddressCommand company)
        {
            var response = await mediator.Send(company);
            if (!response.Success && response.ValidationErrors.Count > 0)
                return UnprocessableEntity(response);

            return Ok(response);
        }
    }
}
