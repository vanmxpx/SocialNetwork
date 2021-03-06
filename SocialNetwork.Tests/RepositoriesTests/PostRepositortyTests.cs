using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SocialNetwork;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using Xunit;


namespace SocialNetwork.Tests
{
    public class PostRepositoryTests
    {
        private ShortyContext context;
        private readonly PostRepository repository;

        public PostRepositoryTests()
        {
            //INITIALIZATION
            this.context = new DbContextCreator().GetDbContext();
            this.repository = new PostRepository(context);
        }

        [Theory]
        [InlineData(1,"vitae, sodales at, velit. Pellentesque ultricies dignissim lacus. Aliquam rutrum")]
        [InlineData(11,"dis parturient montes, nascetur ridiculus mus. Donec dignissim magna a")]
        [InlineData(31,"mi pede, nonummy ut, molestie in, tempus eu, ligula. Aenean")]
        public void GetByIdTest_Post_Expected(int id, string text)
        {   
            
            //WHEN
            Post post = repository.GetById(id).Result;
            //THEN
            Assert.NotNull(post);
            Assert.Equal(text, post.Text);
        }

        [Theory]
        [InlineData(39, 3)]
        [InlineData(9, 2)]
        public void GetByIdTest_Posts_Expect(int id, int arrayLenght)
        {   
            //WHEN
            ICollection<Post> posts = repository.GetByAuthorId(id).Result;
            //THEN
            Assert.NotNull(posts);
            Assert.Equal(arrayLenght, posts.Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(150)]
        public void GetByIdTest_Null_Expected(int id)
        {   
            //WHEN
            Post post = repository.GetById(id).Result;
            //THEN
            Assert.True(post == null);
        }

        [Fact]
        public void GetAllTest()
        {   
            //WHEN
            ICollection<Post> list = repository.GetAll().ToListAsync().Result;
            //THEN
            Assert.Equal(100, list.Count);
        }

        [Fact]
        public async void CreatePostTest()
        {   
            //WHEN
            await repository.Create(new Post{Id = 101, Text = "ased tortor. Integer aliqscing lacus", ProfileRef = 1});
            await context.SaveChangesAsync();
            Post post = await repository.GetById(101);
            //THEN
            Assert.Equal("ased tortor. Integer aliqscing lacus", post.Text);
        }

        [Fact]
        public async void UpdatePostTest()
        {   
            //WHEN
            Post post = await repository.GetById(1);
            post.Text = "Lorem ipsum sit amet";
            repository.Update(1, post);
            await context.SaveChangesAsync();
            post = await repository.GetById(1);
            //THEN
            Assert.Equal("Lorem ipsum sit amet", post.Text);
        }

        [Fact]
        public async void DeletePostTest()
        {   
            //WHEN
            Post post =  repository.GetById(1).Result;
            repository.Delete(post);
            await context.SaveChangesAsync();
        }

    }
}