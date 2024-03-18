using BookingService.Application.Common;

namespace BookingService.Application.UseCase.Post.Commands.CreatePost
{
    public class CreatePostCommandResponse : BaseResponse
    {
        public int? PostId { get; set; }
        public CreatePostCommandResponse() : base()
        { }

        public CreatePostCommandResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public CreatePostCommandResponse(string message)
        : base(message)
        { }

        public CreatePostCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public CreatePostCommandResponse(int postId)
        {
            PostId = postId;
        }
    }
}
