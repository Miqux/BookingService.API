using MediatR;

namespace BookingService.Application.UseCase.Post.Command.CreatedPost
{
    public class CreatedPostCommand : IRequest<CreatedPostCommandResponse>
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
