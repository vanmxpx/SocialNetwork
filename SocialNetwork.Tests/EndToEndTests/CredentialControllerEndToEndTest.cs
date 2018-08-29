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
    public class CredentialsControllerEndToEndTest
    {
        private bool SamePost(Post p1, Post p2)
        {
            return p1.Id == p2.Id && p1.Text == p2.Text && p1.ProfileRef == p2.ProfileRef && p1.Datetime == p2.Datetime;
        }

        [Fact]
        public async void GetCredentialByEmailSmokeTests()
        {
            using (var httpClient = HttpClientCreator.GetHttpClient())
            {
                var response = await httpClient.GetAsync("api/credentials/nulla.Integer@nuncsitamet.com", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                string jsonString = null;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Assert.NotNull(jsonString);
                }
                Credential credential = JsonConvert.DeserializeObject<Credential>(jsonString);
                Assert.NotNull(credential);
                Assert.Equal(4, credential.Id);
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
        public async void PostActionTest()
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
                Assert.True(SamePost(newPost, post));
                //var deleteResponse = await httpClient.DeleteAsync("api/posts/150");
            }
        }

        [Fact]
        public async void DeleteActionTest()
        {
            var httpClient = HttpClientCreator.GetHttpClient();
            var deleteResponse = await httpClient.DeleteAsync("api/credentials/50");
            Assert.True(deleteResponse.IsSuccessStatusCode);
        }
    }
}
