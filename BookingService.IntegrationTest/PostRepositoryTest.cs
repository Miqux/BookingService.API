using AutoMapper;
using BookingService.Application.Mapper;
using BookingService.Application.UseCase.Post.Command.CreatedPost;
using BookingService.Application.UseCase.Post.Queries.GetPosts;
using BookingService.Infrastructure.Persistence;
using BookingService.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace BookingService.IntegrationTest
{
#nullable disable
    public class PostRepositoryTest
    {
        [Test, Isolated]
        public async Task Add_GetValidPost_ShouldReturn3Posts()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<BookingServiceContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BookingServiceConnectionString"));
            var context = new BookingServiceContext(optionsBuilder.Options);
            var mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingConfiguration>();
            }).CreateMapper();
            var postRepository = new PostRepository(context);
            var result = await new GetPostsHandler(mapper, postRepository).Handle(new GetPostsQuery(), new CancellationToken());

            Assert.That(result.Count, Is.EqualTo(3));
        }

        [Test, Isolated]
        public async Task Add_AddValidPost_ShouldReturnSuccess()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<BookingServiceContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BookingServiceConnectionString"));
            var context = new BookingServiceContext(optionsBuilder.Options);
            var mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingConfiguration>();
            }).CreateMapper();
            var postRepository = new PostRepository(context);
            var result = await new CreatedPostCommandHandler(postRepository, mapper)
                .Handle(new CreatedPostCommand() { Content = "Testowy post", Title = "Testowa zawartość postu" }, new CancellationToken());

            Assert.That(result.Success, Is.EqualTo(true));
            Assert.That(result.PostId, Is.GreaterThan(0));
        }
    }
}