using System;
using Microsoft.EntityFrameworkCore;
using SocialNetwork;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using Xunit;


namespace SocialNetworkTests
{
    public class ProfileRepositoryTests
    {
        private readonly ProfileRepository repository;

        public ProfileRepositoryTests()
        {
            this.repository = new ProfileRepository(DbContextCreator.GetDbContext());
        }

        [Fact]
        public void GetByIdReturnsLoginTest()
        {   
            //WHEN
            Profile profile = repository.GetById(1).Result;
            //THEN
            Assert.True(profile.Login == "Vestibulum");
        }

        [Fact]
        public void GetByIdReturnsNullTest()
        {   
            //WHEN
            Profile profile = repository.GetById(0).Result;
            //THEN
            Assert.True(profile == null);
        }

        [Fact]
        public void GetByIdReturnsNullTest()
        {   
            //WHEN
            Profile profile = repository.GetById(0).Result;
            //THEN
            Assert.True(profile == null);
        }
    }
}