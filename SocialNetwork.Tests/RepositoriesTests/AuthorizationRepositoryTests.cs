using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SocialNetwork;
using SocialNetwork.Repositories;
using SocialNetwork.Tests;
using Xunit;

namespace SocialNetworkTests
{
    public class AuthorizationRepositoryTests
    {
        private readonly ShortyContext context;
        private readonly AuthorizationRepository repository;
        public AuthorizationRepositoryTests()
        {
             //INITIALIZATION
             this.context = new DbContextCreator().GetDbContext();
             this.repository = new AuthorizationRepository(context);
        }

        [Theory]
        [InlineData(1, "2019-09-09 09:30:44")]
        [InlineData(11, "2019-09-05 21:06:38")]
        [InlineData(21, "2019-09-26 04:32:53")]
        public void GetByIdTest_Authorization_Expected(int id, string dateTime)
        {   
            //WHEN
            Authorization authorization = repository.GetById(id).Result;
            //THEN
            Assert.Equal(dateTime, authorization.DatetimeRequest.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        [Fact]
        public async void GetAllTest()
        {   
            //WHEN
            ICollection<Authorization> list = await repository.GetAll().ToListAsync();
            //THEN
            Assert.Equal(100, list.Count);
        }

        [Fact]
        public async void UpdateAuthorizationTest()
        {   
            //WHEN
            Authorization authorization = await repository.GetById(50);
            DateTime dateTime = new DateTime();
            authorization.DatetimeRequest = dateTime;
            repository.Update(50, authorization);
            await context.SaveChangesAsync();
            authorization = await repository.GetById(50);
            //THEN
            Assert.Equal(dateTime, authorization.DatetimeRequest);
        }

        [Fact]
        public async void CreateAuthorizationTest()
        {   
            //WHEN
            await repository.Create(new Authorization{Id = 101, SystemStatus = "1", CredentialRef = 5, DatetimeStart = new DateTime(), DatetimeRequest = new DateTime()});
            await context.SaveChangesAsync();
            Authorization authorization = await repository.GetById(101);
            //THEN
            Assert.Equal(5, authorization.CredentialRef);
        }
    }
}