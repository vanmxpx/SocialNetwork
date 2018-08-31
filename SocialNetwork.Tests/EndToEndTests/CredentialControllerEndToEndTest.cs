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
        public async void DeleteActionTest()
        {
            var httpClient = HttpClientCreator.GetHttpClient();
            var deleteResponse = await httpClient.DeleteAsync("api/credentials/50");
            Assert.True(deleteResponse.IsSuccessStatusCode);
        }
    }
}
