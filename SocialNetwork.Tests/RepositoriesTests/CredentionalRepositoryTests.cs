using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SocialNetwork;
using SocialNetwork.Repositories;
using SocialNetwork.Tests;
using Xunit;

namespace SocialNetworkTests
{
    public class CredentionalRepositoryTests
    {
        private readonly ShortyContext context;
        private readonly CredentialRepository repository;

        public CredentionalRepositoryTests()
        {
             //INITIALIZATION
             this.context = new DbContextCreator().GetDbContext(); 
             this.repository = new CredentialRepository(context);
        }

        [Theory]
        [InlineData(1, "rutrum.justo.Praesent@nec.net")]
        [InlineData(11, "elit@egetmollislectus.com")]
        [InlineData(21, "placerat.orci@hendreritDonecporttitor.edu")]
         public void GetByEmailTest(int id, string email)
         {
             //WHEN
             Credential credential = repository.GetByEmail(email).Result;
             //THEN
             Assert.Equal(id, credential.Id);
         }

        [Theory]
        [InlineData(1, "rutrum.justo.Praesent@nec.net")]
        [InlineData(11, "elit@egetmollislectus.com")]
        [InlineData(21, "placerat.orci@hendreritDonecporttitor.edu")]
         public void GetByIdTest(int id, string email)
         {
             //WHEN
             Credential credential = repository.GetById(id).Result;
             //THEN
             Assert.Equal(email, credential.Email);
         }

        [Theory]
        [InlineData(true, "rutrum.justo.Praesent@nec.net")]
        [InlineData(true, "elit@egetmollislectus.com")]
        [InlineData(false, "test@gmail.com")]
         public void DoesExistEmailTest(bool flag, string email)
         {
             //WHEN
             bool doesExist = repository.IsExist(email).Result;
             //THEN
             Assert.Equal(flag, doesExist);
         }

        [Fact]
        public async void UpdateCredentionalTest()
        {   
            //WHEN
            Credential credential = await repository.GetById(50);
            credential.Password = "QWERTY1234";
            repository.Update(50, credential);
            await context.SaveChangesAsync();
            credential = await repository.GetById(50);
            //THEN
            Assert.Equal("QWERTY1234", credential.Password);
        }

        [Fact]
        public async void DeleteCredentionalTest()
        {   
            //WHEN
            Credential credential = await repository.GetById(49);
            //THEN
            repository.Delete(credential);
            await context.SaveChangesAsync();
        }
    }
}