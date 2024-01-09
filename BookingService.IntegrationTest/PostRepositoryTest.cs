using AutoMapper;
using BookingService.Application.Mapper;
using BookingService.Application.UseCase.Post.Command.CreatedPost;
using BookingService.Application.UseCase.Post.Queries.GetPosts;
using BookingService.Infrastructure.Persistence.Repository;
using NUnit.Framework;

namespace BookingService.IntegrationTest
{
#nullable disable
    public class PostRepositoryTest
    {
        [Test, Isolated]
        public async Task Add_GetValidPost_ShouldReturn4Posts()
        {
            var mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingConfiguration>();
            }).CreateMapper();
            var postRepository = new PostRepository(DatabaseProvider.GetApplicationContext());

            var result = await new GetPostsHandler(mapper, postRepository).Handle(new GetPostsQuery(), new CancellationToken());

            Assert.That(result.Count, Is.EqualTo(4));
        }

        [Test, Isolated]
        public async Task Add_AddValidPost_ShouldReturnSuccess()
        {
            var mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingConfiguration>();
            }).CreateMapper();
            var postRepository = new PostRepository(DatabaseProvider.GetApplicationContext());

            var result = await new CreatedPostCommandHandler(postRepository, mapper)
                .Handle(new CreatedPostCommand() { Content = "Testowy post", Title = "Testowa zawartość postu" }, new CancellationToken());

            Assert.That(result.Success, Is.EqualTo(true));
            Assert.That(result.PostId, Is.GreaterThan(0));
        }
    }
}