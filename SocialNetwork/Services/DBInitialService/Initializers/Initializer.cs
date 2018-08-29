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
            SC.Database.Migrate();
        }

        public async Task DeleteAll()
        {
            checkOnExistingDatabase();

            if (SC.Authorizations.Any())
                SC.Authorizations.RemoveRange(SC.Authorizations);

            if (SC.Followers.Any())
                SC.Followers.RemoveRange(SC.Followers);

            if (SC.Posts.Any())
                SC.Posts.RemoveRange(SC.Posts);

            if (SC.Credentials.Any())
                SC.Credentials.RemoveRange(SC.Credentials);

            if (SC.Profiles.Any())
                SC.Profiles.RemoveRange(SC.Profiles);

            await SC.SaveChangesAsync();
        }

        public async Task Seed()
        {
            checkOnExistingDatabase();
            string sqlDatabaseFill = File.ReadAllText("addTestData.sql");
            int numberOfRowInserted = SC.Database.ExecuteSqlCommand(sqlDatabaseFill);

            //   if (!SC.Authorizations.Any())
            //       SC.Authorizations.RemoveRange(SC.Authorizations);

            //   if (!SC.Followers.Any())
            //       SC.Followers.RemoveRange(SC.Followers);

            //  if (!SC.Posts.Any())
            //       SC.Posts.RemoveRange(SC.Posts);
            // if (!SC.Profiles.Any())
            //     SC.Profiles.AddRange(profiles);

            //     SC.SaveChanges();

            // if (!SC.Userdata.Any())
            //     SC.Userdata.AddRange(Userdatas);

            await SC.SaveChangesAsync();
        }
        // #region Profile
        // List<Profile> profiles = new List<Profile>(){
        //     new Profile(){Email = "drecrithet@matra.site", Password = "h6xc4Rb8&fbP"},
        //     new Profile(){Email = "donotrespond@pof.com", Password = "C%knyNXy6&$A&fbP"},
        //     new Profile(){Email = "userservices@eharmony.com", Password = "K*c4P@URhxye&fbP"},
        //     new Profile(){Email = "ghemn.kataa@dpttso8dag0.cf", Password = "GJ&^F9bDfVEx"},
        //     new Profile(){Email = "jginspace@outlook.com", Password = "RHJ$SaB52&ds"}
        // };
        // #endregion
        // #region UserData
        // List<Userdata> Userdatas = new List<Userdata>(){
        //     new Userdata(){IdProfile = 1, Login = "admiral", Name="John",LastName="Minsky"}//, Location="Ezreuford",Age=25,Gender=0},
        //     //  new Userdata(){IdProfile = 2, Login = "TheBigPig", Name="Ursula",LastName="Boyd", Location="Deokreit",Age=19,Gender=1},
        //     //  new Userdata(){IdProfile = 3, Login = "Genius", Name="Cornelius",LastName="Marsh", Location="Hongqiao",Age=22,Gender=0},
        //     //  new Userdata(){IdProfile = 4, Login = "littleKitty", Name="Peny",LastName="Skinner", Location="Cruzeiro",Age=34,Gender=1},
        //     //  new Userdata(){IdProfile = 5, Login = "Destructor", Location="Skopje",Age=23,Gender=2}
        // };
        // #endregion
    }
}