using System;
using Microsoft.EntityFrameworkCore;
using SocialNetwork;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using Xunit;


namespace SocialNetwork.Tests
{
    public class PostRepositoryTests
    {
        private readonly PostRepository repository;

        public PostRepositoryTests()
        {
            this.repository = new PostRepository(DbContextCreator.GetDbContext());
        }

        [Fact]
        public void GetByIdReturnsLoginTest()
        {   
            //WHEN
            Post post = repository.GetById(37).Result;
            //THEN
            Assert.NotNull(post);
            Assert.Equal(37, post.Id);
            Assert.Equal(2, post.ProfileRef);
            Assert.Equal("posuere cubilia Curae; Donec tincidunt. Donec vitae erat vel pede", post.Text);
            Assert.Equal(DateTime.Parse("2019/08/22 19:47:06"), post.Datetime);
        }

        [Fact]
        public void GetByIdReturnsNullTest()
        {   
            //WHEN
            Post post = repository.GetById(0).Result;
            //THEN
            Assert.True(post == null);
        }
    }
}