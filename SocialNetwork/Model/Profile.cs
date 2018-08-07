using System;
using System.Collections.Generic;

namespace SocialNetwork
{
    public enum Gender : byte
    {
        Male = 0,
        Female = 1,
        NotSet = 2
    }

    public class Profile
    {
        public Profile()
        {
            Blogers = new HashSet<Followers>();
            Subscribers = new HashSet<Followers>();
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Location { get; set; }
        public byte? Age { get; set; }
        public byte[] Photo { get; set; }

        public ICollection<Followers> Blogers { get; set; }
        public ICollection<Followers> Subscribers { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
