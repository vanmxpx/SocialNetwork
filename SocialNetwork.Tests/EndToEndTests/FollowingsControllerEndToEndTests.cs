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
    public class FollowingsControllerEndToEndTest
    {

        private bool SameRelationCheck(Followings p1, Followings p2)
        {
            return p1.Id == p2.Id && p1.BloggerRef == p2.BloggerRef && p1.SubscriberRef == p2.SubscriberRef;
        }

        [Fact]
        public async void GetBloggersByProfileIdSmokeTests()
        {
            using (var httpClient = HttpClientCreator.GetHttpClient())
            {
                var response = await httpClient.GetAsync("api/followings/bloggers/?id=24", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(true);
                string jsonString = null;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Assert.NotNull(jsonString);
                }
                List<Profile> bloggers = JsonConvert.DeserializeObject<List<Profile>>(jsonString);
                Assert.NotNull(bloggers);
                Assert.Equal(3, bloggers.Count);
            }
        }

        [Fact]
        public async void GetSubscribersByProfileIdSmokeTests()
        {
            using (var httpClient = HttpClientCreator.GetHttpClient())
            {
                var response = await httpClient.GetAsync("api/followings/subscribers/?id=24", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(true);
                string jsonString = null;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Assert.NotNull(jsonString);
                }
                List<Profile> subscribers = JsonConvert.DeserializeObject<List<Profile>>(jsonString);
                Assert.NotNull(subscribers);
                Assert.Equal(3, subscribers.Count);
            }
        }

        [Fact]
        public async void CreateRealtionshipActionTest()
        {
            using (var httpClient = HttpClientCreator.GetHttpClient())
            {
                var following = new Followings { Id = 1000, BloggerRef = 5, SubscriberRef = 16 };
                var followingJson = JsonConvert.SerializeObject(following);
                var httpContent = new StringContent(followingJson, Encoding.UTF8, "application/json");
                var newFollowingResponse = await httpClient.PostAsync("api/followings", httpContent);
                Assert.True(newFollowingResponse.IsSuccessStatusCode);
                var newProductJson = await newFollowingResponse.Content.ReadAsStringAsync();
                var newPost = JsonConvert.DeserializeObject<Followings>(newProductJson);
                Assert.True(SameRelationCheck(newPost, following));
            }
        }
    }
}
