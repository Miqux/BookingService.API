using BookingService.Application.UseCase.Post.Command.CreatedPost;
using BookingService.Application.UseCase.Post.Queries.GetPosts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator mediator;

        public PostController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<CreatedPostCommandResponse>> Post([FromBody] CreatedPostCommand model)
        {
            var response = await mediator.Send(model);
            if (!response.Success && response.ValidationErrors.Count > 0)
                return UnprocessableEntity(response);

            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<List<PostViewModel>>> Get()
        {
            var response = await mediator.Send(new GetPostsQuery());

            if (response is null)
                return NotFound();

            return Ok(response);
        }
    }
}
