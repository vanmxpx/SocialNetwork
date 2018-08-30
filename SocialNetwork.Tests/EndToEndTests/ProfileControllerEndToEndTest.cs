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
    public class ProfileControllerEndToEndTest
    {

        [Fact]
        public async void GetProfileByIdSmokeTests()
        {
            using (var httpClient = HttpClientCreator.GetHttpClient())
            {
                var response = await httpClient.GetAsync("api/profiles/37", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                string jsonString = null;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Assert.NotNull(jsonString);
                }
                Profile profile = JsonConvert.DeserializeObject<Profile>(jsonString);
                Assert.NotNull(profile);
                Assert.Equal(37, profile.Id);
                Assert.Equal("molestie", profile.Login);
                Assert.Equal("Mariko", profile.Name);
                Assert.Equal("Bright", profile.LastName);
            }
        }

        [Fact]
        public async void GetProfileByLoginSmokeTests()
        {
            using (var httpClient = HttpClientCreator.GetHttpClient())
            {
                var response = await httpClient.GetAsync("api/profiles/login/?login=Fusce", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                string jsonString = null;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Assert.NotNull(jsonString);
                }
                Profile profile = JsonConvert.DeserializeObject<Profile>(jsonString);
                Assert.NotNull(profile);
                Assert.Equal(10, profile.Id);
                Assert.Equal("Fusce", profile.Login);
            }
        }

        [Fact]
        public async void GetProfileByNameIdSmokeTests()
        {
            using (var httpClient = HttpClientCreator.GetHttpClient())
            {
                var response = await httpClient.GetAsync("api/profiles/name/?name=Kirk&lastName=Chapman", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                string jsonString = null;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Assert.NotNull(jsonString);
                }
                List<Profile> profiles = JsonConvert.DeserializeObject<List<Profile>>(jsonString);
                Assert.NotNull(profiles);
                Assert.Equal(1, profiles.Count);
            }
        }

        [Fact]
        public async void DeleteActionTest()
        {
            var httpClient = HttpClientCreator.GetHttpClient();
            var deleteResponse = await httpClient.DeleteAsync("api/profiles/50");
            Assert.True(deleteResponse.IsSuccessStatusCode);
        }
    }
}
