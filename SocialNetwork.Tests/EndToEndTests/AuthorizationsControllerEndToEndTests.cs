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
    public class AuthorizationsControllerEndToEndTest
    {
        private bool SameAuthorizationsCheck(Authorization authorization1, Authorization authorization2)
        {
            return authorization1.Id == authorization2.Id 
            && authorization1.CredentialRef == authorization2.CredentialRef 
            && authorization1.DatetimeStart==authorization2.DatetimeStart 
            && authorization1.DatetimeRequest ==authorization2.DatetimeRequest;
        }

        [Fact]
        public async void GetAuthorizationByIdSmokeTests()
        {
            using (var httpClient = HttpClientCreator.GetHttpClient())
            {
                var response = await httpClient.GetAsync("api/authorizations/29", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                string jsonString = null;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Assert.NotNull(jsonString);
                }
                Authorization authorization = JsonConvert.DeserializeObject<Authorization>(jsonString);
                Assert.NotNull(authorization);
                Assert.Equal(6, authorization.CredentialRef);
            }
        }

        [Fact]
        public async void GetAuthorizationsByCredentialIdSmokeTests()
        {
            using (var httpClient = HttpClientCreator.GetHttpClient())
            {
                var response = await httpClient.GetAsync("api/authorizations/?credentialId=39", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(true);
                string jsonString = null;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Assert.NotNull(jsonString);
                }
                List<Authorization> authorizations = JsonConvert.DeserializeObject<List<Authorization>>(jsonString);
                Assert.NotNull(authorizations);
                Assert.Equal(3, authorizations.Count);
            }
        }

        [Fact]
        public async void AuthorizationPostActionTest()
        {
            using (var httpClient = HttpClientCreator.GetHttpClient())
            {
                var credentialDto = new CredentialDto { Email="quam.dignissim.pharetra@Duisgravida.edu", Password="Nullam"  };
                var postJson = JsonConvert.SerializeObject(credentialDto);
                var httpContent = new StringContent(postJson, Encoding.UTF8, "application/json");
                var newPostResponse = await httpClient.PostAsync("api/authorizations", httpContent);
                Assert.True(newPostResponse.IsSuccessStatusCode);
            }
        }

        [Fact]
        public async void DeleteActionTest()
        {
            var httpClient = HttpClientCreator.GetHttpClient();
            var deleteResponse = await httpClient.DeleteAsync("api/authorizations/49");
            Assert.True(deleteResponse.IsSuccessStatusCode);
        }
    }
}
