using BookingService.Application.Common;
using FluentValidation.Results;

namespace BookingService.Application.UseCase.Post.Command.CreatedPost
{
    public class CreatedPostCommandResponse : BaseResponse
    {
        public int? PostId { get; set; }
        public CreatedPostCommandResponse() : base()
        { }

        public CreatedPostCommandResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public CreatedPostCommandResponse(string message)
        : base(message)
        { }

        public CreatedPostCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public CreatedPostCommandResponse(int postId)
        {
            PostId = postId;
        }
    }
}
