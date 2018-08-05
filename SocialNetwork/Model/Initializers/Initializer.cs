using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork
{
    public class Intitializer
    {

        private ShortyContext SC;
        public Intitializer(ShortyContext SC)
        {
            this.SC = SC;
        }
        public async Task DeleteAll()
        {
            if (SC.Authorizations.Any())
                SC.Authorizations.RemoveRange(SC.Authorizations);

            if (SC.Followers.Any())
                SC.Followers.RemoveRange(SC.Followers);

            if (SC.Posts.Any())
                SC.Posts.RemoveRange(SC.Posts);

            if (SC.Userdata.Any())
                SC.Userdata.RemoveRange(SC.Userdata);

            if (SC.Profiles.Any())
                SC.Profiles.RemoveRange(SC.Profiles);

            await SC.SaveChangesAsync();
        }

        public async Task Seed()
        {
         //   if (!SC.Authorizations.Any())
         //       SC.Authorizations.RemoveRange(SC.Authorizations);

         //   if (!SC.Followers.Any())
         //       SC.Followers.RemoveRange(SC.Followers);

          //  if (!SC.Posts.Any())
         //       SC.Posts.RemoveRange(SC.Posts);

          //  if (!SC.Userdata.Any())
          //      SC.Userdata.RemoveRange(SC.Userdata);

            if (!SC.Profiles.Any())
                SC.Profiles.AddRange(profiles);

            await SC.SaveChangesAsync();
        }
        #region Profile
        List<Profile> profiles = new List<Profile>(){
new Profile(){Email = "drecrithet@matra.site", Password = "h6xc4Rb8&fbP"},
new Profile(){Email = "donotrespond@pof.com", Password = "C%knyNXy6&$A&fbP"},
new Profile(){Email = "userservices@eharmony.com", Password = "K*c4P@URhxye&fbP"},
new Profile(){Email = "ghemn.kataa@dpttso8dag0.cf", Password = "GJ&^F9bDfVEx"},
new Profile(){Email = "jginspace@outlook.com", Password = "RHJ$SaB52&ds"}
        };
        #endregion
    }
}