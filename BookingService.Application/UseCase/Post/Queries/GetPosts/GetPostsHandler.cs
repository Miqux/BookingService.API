using AutoMapper;
using BookingService.Application.Contracts.Persistance;
using MediatR;

namespace BookingService.Application.UseCase.Post.Queries.GetPosts
{
    public class GetPostsHandler : IRequestHandler<GetPostsQuery, List<PostViewModel>>
    {
        private readonly IMapper mapper;
        private readonly IPostRepository postRepository;

        public GetPostsHandler(IMapper mapper, IPostRepository postRepository)
        {
            this.mapper = mapper;
            this.postRepository = postRepository;
        }
        public async Task<List<PostViewModel>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await postRepository.GetAllAsync();
            return mapper.Map<List<PostViewModel>>(posts);
        }
    }
}
