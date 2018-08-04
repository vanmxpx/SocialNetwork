using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork
{
    public partial class Profile
    {
        public Profile()
        {
            Authorizations = new HashSet<Authorizations>();
            FollowersIdProfileBlogerNavigation = new HashSet<Followers>();
            FollowersIdProfileSubscriberNavigation = new HashSet<Followers>();
            Post = new HashSet<Post>();
        }

        public int IdProfile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateRegistration { get; set; }

        public Userdata IdUserdataNavigation { get; set; }
        public ICollection<Authorizations> Authorizations { get; set; }
        public ICollection<Followers> FollowersIdProfileBlogerNavigation { get; set; }
        public ICollection<Followers> FollowersIdProfileSubscriberNavigation { get; set; }
        public ICollection<Post> Post { get; set; }
    }
}
