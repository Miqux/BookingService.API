using BookingService.Application.UseCase.Company.Command.CreatedCompany;
using BookingService.Application.UseCase.Company.Command.UpdatedComapnyWithAddress;
using BookingService.Application.UseCase.Company.Queries.GetCompanyByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<CreatedCompanyCommandResponse>> Post([FromBody] CreatedCompanyCommand createdCompany)
        {
            var response = await mediator.Send(createdCompany);
            if (!response.Success && response.ValidationErrors.Count > 0)
                return UnprocessableEntity(response);

            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<UpdatedCompanyWithAddressCommandResponse>> Update(UpdatedCompanyWithAddressCommand company)
        {
            var response = await mediator.Send(company);
            if (!response.Success && response.ValidationErrors.Count > 0)
                return UnprocessableEntity(response);

            return Ok(response);
        }
    }
}
