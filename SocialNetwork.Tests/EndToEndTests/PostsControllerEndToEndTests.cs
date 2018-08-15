using Xunit;
using SocialNetwork.Controllers;
using SocialNetwork.Repositories;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SocialNetwork.Tests
{
    public class PostsControllerEndToEndTests
    {
        [Fact]
        public async void GetPostByIdSmokeTests()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:5000/");
                var acceptType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(acceptType);
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
    }
}
