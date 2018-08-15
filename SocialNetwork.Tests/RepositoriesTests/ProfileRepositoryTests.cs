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

        public  ProfileRepositoryTests()
        {
            this.repository = new ProfileRepository(DbContextCreator.GetDbContext());
        }

        [Fact]
        public async void GetByIdTest_Profile_Expected()
        {   
            //WHEN
            await repository.Create(new Profile{Id = 1, Login = "Vestibulum", Name = "Veronica", LastName = "Baldwin"});
            Profile profile = repository.GetById(1).Result;
            //THEN
            Assert.True(profile.Login == "Vestibulum");
        }

        [Fact]
        public async void GetByIdTest_Null_Expected()
        {   
            //WHEN
            await repository.Create(new Profile{Id = 2, Login = "nisi", Name = "Jared", LastName = "Rasmussen"});
            Profile profile = repository.GetById(0).Result;
            //THEN
            Assert.True(profile == null);
        }

        [Fact]
        public async void GetByNameAndLastNameTest_Profile_Expected()
        {   
            //WHEN
            await repository.Create(new Profile{Id = 21, Login = "rutrum", Name = "Curran", LastName = "Pennington"});
            Profile profile = repository.GetByNameAndLastName("Curran","Pennington").Result;
            //THEN
            Assert.True(profile.Id == 21);
        }

        [Fact]
        public async void GetByNameAndLastNameTest_Null_Expected()
        {   
            //WHEN
            await repository.Create(new Profile{Id = 3, Login = "nibh", Name = "Jillian", LastName = "Hayden"});
            Profile profile = repository.GetByNameAndLastName("null","null").Result;
            //THEN
            Assert.True(profile == null);
        }

        [Fact]
        public async void GetByLoginTest_Profile_Expected()
        {   
            //WHEN
            await repository.Create(new Profile{Id = 41, Login = "iaculis", Name = "Kirk", LastName = "Chapman"});
            Profile profile = repository.GetByLogin("iaculis").Result;
            //THEN
            Assert.True(profile.Id == 41);
        }

        [Fact]
        public void GetByLoginTest_Null_Expected()
        {   
            //WHEN
            Profile profile = repository.GetByLogin("notExistedLogin").Result;
            //THEN
            Assert.True(profile == null);
        }

        [Fact]
        public async void GetAllTest()
        {   
            //WHEN
            Profile profile = new Profile{Id = 4, Login = "Aliquam", Name = "Rigel", LastName = "Burks"};
            await repository.Create(profile);
            await repository.Create(new Profile{Id = 5, Login = "Nullam", Name = "Owen", LastName = "Emerson"});
            var list = await repository.GetAll().ToListAsync();
            //THEN
            Assert.True(list.Find(p => p.Id == 4).Login == "Aliquam");
        }

        [Fact]
        public async void CreateTest()
        {   
            //WHEN
            await repository.Create(new Profile{Id = 13, Login = "Quisque", Name = "Raja", LastName = "Ruiz"});
            Profile profile = await repository.GetById(13);
            //THEN
            Assert.True(profile.Id == 13);
        }

        [Fact]
        public async void UpdateTest()
        {   
            //WHEN
            Profile profile = new Profile{Id = 15, Login = "Quisque", Name = "Raja", LastName = "Ruiz"};
            await repository.Create(profile);
            profile.Login = "newLogin";
            await repository.Update(15, profile);
            Profile updatedProfile = await repository.GetById(15);
            //THEN
            Assert.True(profile.Login == "newLogin");
        }

        // [Fact]
        // public async void DeleteTest()
        // {   
        //     DbContextCreator.GetDbContext().Database.EnsureDeleted();
        //     //WHEN
        //     await repository.Create(new Profile{Id = 7, Login = "nunc", Name = "Leilani", LastName = "Pena"});
        //     await repository.Delete(7);
        //     Profile profile = await repository.GetById(7);
        //     //THEN
        //     Assert.True(profile == null);
        // }
    }
}