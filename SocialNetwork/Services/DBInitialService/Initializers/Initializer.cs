using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork
{
    public class Initializer
    {
        private ShortyContext SC;
        public Initializer(ShortyContext SC)
        {
            this.SC = SC;
        }

        private void checkOnExistingDatabase()
        {
            
        }

        public async Task DeleteAll()
        {
            await SC.Database.EnsureDeletedAsync();
            // checkOnExistingDatabase();

            // if (SC.Authorizations.Any())
            //     SC.Authorizations.RemoveRange(SC.Authorizations);

            // if (SC.Followers.Any())
            //     SC.Followers.RemoveRange(SC.Followers);

            // if (SC.Posts.Any())
            //     SC.Posts.RemoveRange(SC.Posts);

            // if (SC.Credentials.Any())
            //     SC.Credentials.RemoveRange(SC.Credentials);

            // if (SC.Profiles.Any())
            //     SC.Profiles.RemoveRange(SC.Profiles);

            await SC.SaveChangesAsync();
        }

        public async Task Seed(bool isTests)
        {
            await SC.Database.EnsureCreatedAsync();
            // checkOnExistingDatabase();
            string sqlDatabaseFill = isTests ?
            File.ReadAllText("addTestData.sql")
            : File.ReadAllText(
                Directory.GetCurrentDirectory() + "\\Services\\DBInitialService\\TestData\\addTestData.sql");
            int numberOfRowInserted = SC.Database.ExecuteSqlCommand(sqlDatabaseFill);
            await SC.SaveChangesAsync();
        }
    }
}