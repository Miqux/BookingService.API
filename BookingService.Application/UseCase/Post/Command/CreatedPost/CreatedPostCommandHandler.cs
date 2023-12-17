using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using MediatR;

namespace BookingService.Application.UseCase.Post.Command.CreatedPost
{
    public class CreatedPostCommandHandler : IRequestHandler<CreatedPostCommand, CreatedPostCommandResponse>
    {
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public CreatedPostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }
        public async Task<CreatedPostCommandResponse> Handle(CreatedPostCommand request, CancellationToken cancellationToken)
        {
            var validator = await new CreatedPostCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validator.IsValid)
                return new CreatedPostCommandResponse(validator);

            var post = mapper.Map<Domain.Entities.Post>(request);
            var addedPost = await postRepository.AddAsync(post);

            return new CreatedPostCommandResponse(addedPost.Id);

        }
    }
}
