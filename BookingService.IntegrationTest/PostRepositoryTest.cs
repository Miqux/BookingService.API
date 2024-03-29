﻿using AutoMapper;
using BookingService.Application.Mapper;
using BookingService.Application.UseCase.Post.Commands.CreatePost;
using BookingService.Application.UseCase.Post.Queries.GetPosts;
using BookingService.Infrastructure.Persistence.Repository;
using NUnit.Framework;

namespace BookingService.IntegrationTest
{
#nullable disable
    public class PostRepositoryTest
    {
        [Test, Isolated]
        public async Task GetValidPost_ShouldReturnNotNull()
        {
            var mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingConfiguration>();
            }).CreateMapper();
            var postRepository = new PostRepository(DatabaseProvider.GetApplicationContext());

            var result = await new GetPostsHandler(mapper, postRepository).Handle(new GetPostsQuery(), new CancellationToken());

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test, Isolated]
        public async Task AddValidPost_ShouldReturnSuccess()
        {
            var mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingConfiguration>();
            }).CreateMapper();
            var postRepository = new PostRepository(DatabaseProvider.GetApplicationContext());

            var result = await new CreatePostCommandHandler(postRepository, mapper)
                .Handle(new CreatePostCommand() { Content = "Testowy post", Title = "Testowa zawartość postu" }, new CancellationToken());

            Assert.That(result.Success, Is.EqualTo(true));
            Assert.That(result.PostId, Is.GreaterThan(0));
        }
    }
}