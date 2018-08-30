using Xunit;
using SocialNetwork.Controllers;
using SocialNetwork.Repositories;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

// For using EndToEnd Testing you need start to Debug process with new test database
namespace SocialNetwork.Tests
{
    public class PostsControllerEndToEndTest
    {
        private bool SamePostCheck(Post post1, Post post2)
        {
            return
            post1.Id == post2.Id
            && post1.Text == post2.Text
            && post1.ProfileRef == post2.ProfileRef
            && post1.Datetime == post2.Datetime;
        }

        [Fact]
        public async void GetPostByIdSmokeTests()
        {
            using (var httpClient = HttpClientCreator.GetHttpClient())
            {
                var response = await httpClient.GetAsync("api/posts/37", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                string jsonString = null;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Assert.NotNull(jsonString);
                }
                Post post = JsonConvert.DeserializeObject<Post>(jsonString);
                Assert.NotNull(post);
                Assert.Equal(37, post.Id);
                Assert.Equal("posuere cubilia Curae; Donec tincidunt. Donec vitae erat vel pede", post.Text);
            }
        }

        [Fact]
        public async void GetPostByAuthorIdSmokeTests()
        {
            using (var httpClient = HttpClientCreator.GetHttpClient())
            {
                var response = await httpClient.GetAsync("api/posts/?AuthorId=39", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(true);
                string jsonString = null;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Assert.NotNull(jsonString);
                }
                List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(jsonString);
                Assert.NotNull(posts);
                Assert.Equal(3, posts.Count);
            }
        }

        [Fact]
        public async void PostPostActionTest()
        {
            using (var httpClient = HttpClientCreator.GetHttpClient())
            {
                var post = new Post { Id = 150, Text = "Test Post", ProfileRef = 7, Datetime = DateTime.Parse("2019/08/18 08:36:28") };
                var postJson = JsonConvert.SerializeObject(post);
                var httpContent = new StringContent(postJson, Encoding.UTF8, "application/json");
                var newPostResponse = await httpClient.PostAsync("api/posts", httpContent);
                Assert.True(newPostResponse.IsSuccessStatusCode);
                var newProductJson = await newPostResponse.Content.ReadAsStringAsync();
                var newPost = JsonConvert.DeserializeObject<Post>(newProductJson);
                Assert.True(SamePostCheck(newPost, post));
            }
        }

        [Fact]
        public async void DeleteActionTest()
        {
            var httpClient = HttpClientCreator.GetHttpClient();
            var deleteResponse = await httpClient.DeleteAsync("api/posts/99");
            Assert.True(deleteResponse.IsSuccessStatusCode);
        }
    }
}
