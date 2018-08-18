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
        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5000");
            var acceptType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(acceptType);
            return httpClient;
        }

        private bool SamePost(Post p1, Post p2)
        {
            return p1.Id == p2.Id && p1.Text == p2.Text && p1.ProfileRef == p2.ProfileRef && p1.Datetime == p2.Datetime;
        }

        [Fact]
        public async void GetPostByIdSmokeTests()
        {
            using (var httpClient = GetHttpClient())
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
                Assert.Equal(2, post.ProfileRef);
                Assert.Equal("posuere cubilia Curae; Donec tincidunt. Donec vitae erat vel pede", post.Text);
                Assert.Equal(DateTime.Parse("2019/08/22 19:47:06"), post.Datetime);
            }
        }

        [Fact]
        public async void GetPostByAuthorIdSmokeTests()
        {
            using (var httpClient = GetHttpClient())
            {
                var response = await httpClient.GetAsync("api/posts/?AuthorId=39", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
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
        public async void PostActionTest()
        {
            using (var httpClient = GetHttpClient())
            {
                var post = new Post { Id = 150, Text = "Test Post", ProfileRef = 7, Datetime = DateTime.Parse("2019/08/18 08:36:28") };
                var postJson = JsonConvert.SerializeObject(post);
                var httpContent = new StringContent(postJson, Encoding.UTF8, "application/json");
                var newPostResponse = await httpClient.PostAsync("api/posts", httpContent);
                Assert.True(newPostResponse.IsSuccessStatusCode);
                var newProductJson = await newPostResponse.Content.ReadAsStringAsync();
                var newPost = JsonConvert.DeserializeObject<Post>(newProductJson);
                Assert.True(SamePost(newPost, post));
                //var deleteResponse = await httpClient.DeleteAsync("api/posts/150");
            }
        }

        [Fact]
        public async void DeleteActionTest()
        {
            var httpClient = GetHttpClient();
            var deleteResponse = await httpClient.DeleteAsync("api/posts/99");
            Assert.True(deleteResponse.IsSuccessStatusCode);
            deleteResponse = await httpClient.DeleteAsync("api/posts/101");
            Assert.False(deleteResponse.IsSuccessStatusCode);

            // #region post returning
            // var post = new Post { Id = 99, Text = "Test Post", ProfileRef = 7, Datetime = DateTime.Parse("2019/08/18 08:36:28") };
            // var postJson = JsonConvert.SerializeObject(post);
            // var httpContent = new StringContent(postJson, Encoding.UTF8, "application/json");
            // var newPostResponse = await httpClient.PostAsync("api/posts", httpContent);
        }
    }
}
