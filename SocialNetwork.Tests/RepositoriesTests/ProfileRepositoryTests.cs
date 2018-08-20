using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SocialNetwork;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using Xunit;


namespace SocialNetwork.Tests
{
    public class ProfileRepositoryTests
    {
        private readonly ProfileRepository repository;
        public  ProfileRepositoryTests(){
            //INITIALIZATION
            this.repository = new ProfileRepository(DbContextCreator.GetDbContext());
        }    
        

        [Theory]
        [InlineData(1,"Vestibulum")]
        [InlineData(11,"lorem")]
        [InlineData(42,"pharetra.")]
        [InlineData(50,"adipiscing,")]
        public void GetByIdTest_Profile_Expected(int id, string login)
        {   
            //WHEN
            Profile profile = repository.GetById(id).Result;
            //THEN
            Assert.Equal(login, profile.Login);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(50)]
        public void GetByIdTest_Null_Expected(int id)
        {   
            //WHEN
            Profile profile = repository.GetById(0).Result;
            //THEN
            Assert.Equal(null, profile);
        }

        [Theory]
        [InlineData(21, "Curran", "Pennington")]
        [InlineData(31, "Galvin", "Alexander")]
        [InlineData(41, "Kirk", "Chapman")]
        public void GetByNameAndLastNameTest_Profile_Expected(int id, string name, string lastName)
        {   
            //WHEN
            List<Profile> profiles = repository.GetByNameAndLastName(name, lastName).Result;
            //THEN
            Assert.Equal(id, profiles[0].Id);
        }

        [Theory]
        [InlineData("Curran", "Alexander")]
        [InlineData("Galvin", "Pennington")]
        [InlineData("Chapman", "Kirk")]
        public void GetByNameAndLastNameTest_Null_Expected(string name, string lastName)
        {   
            //WHEN
            List<Profile> profiles = repository.GetByNameAndLastName(name, lastName).Result;
            //THEN
            Assert.Equal(0, profiles.Count);
        }

        [Theory]
        [InlineData(41, "iaculis")]
        [InlineData(13, "Quisque")]
        [InlineData(24, "quis")]
        public void GetByLoginTest_Profile_Expected(int id, string login)
        {   
            //WHEN
            Profile profile = repository.GetByLogin(login).Result;
            //THEN
            Assert.Equal(id, profile.Id);
        }

        [Theory]
        [InlineData("notExistedLogin")]
        [InlineData("fakelogin")]
        [InlineData("")]
        public void GetByLoginTest_Null_Expected(string login)
        {   
            //WHEN
            Profile profile = repository.GetByLogin(login).Result;
            //THEN
            Assert.Equal(null, profile);
        }

        [Theory]
        [InlineData(42, "pharetra.")]
        [InlineData(23, "vitae")]
        [InlineData(1, "Vestibulum")]
        public async void GetAllTest(int id, string login)
        {   
            //WHEN
            var list = await repository.GetAll().ToListAsync();
            //THEN
            Assert.True(list.Find(p => p.Id == id).Login == login);
        }

        [Fact]
        public async void CreateTest()
        {   
            //WHEN
            await repository.Create(new Profile{Id = 99, Login = "QuSDFisque", Name = "Raja", LastName = "Kolpakov"});
            Profile profile = await repository.GetById(99);
            //THEN
            Assert.True(profile.LastName == "Kolpakov");
        }

        [Fact]
        public async void UpdateTest()
        {   
            // //WHEN
            Profile profile = await repository.GetById(15);
            profile.Login = "newLogin";
            await repository.Update(15, profile);
            profile = await repository.GetById(15);
            // //THEN
            Assert.True(profile.Login == "newLogin");
        }

        // [Theory]
        // [InlineData(1)]
        // [InlineData(11)]
        // [InlineData(21)]
        // public async void DeleteTest(int id)
        // {   
        //     //WHEN
        //     await repository.Delete(id);
            
        //     Profile profile = await repository.GetById(id);
        //     //THEN
        //     Assert.Equal(null, profile);
        // }
    }
}