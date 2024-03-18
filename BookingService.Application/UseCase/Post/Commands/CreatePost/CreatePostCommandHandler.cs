using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using MediatR;

namespace BookingService.Application.UseCase.Post.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostCommandResponse>
    {
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }
        public async Task<CreatePostCommandResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var validator = await new CreatePostCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validator.IsValid)
                return new CreatePostCommandResponse(validator);

            var post = mapper.Map<Domain.Entities.Post>(request);
            var addedPost = await postRepository.AddAsync(post);

            return new CreatePostCommandResponse(addedPost.Id);

        }
    }
}
