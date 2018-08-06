using System;
using System.Collections.Generic;

namespace SocialNetwork
{
    public partial class Profile
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
        public sbyte Gender { get; set; }
        public string Location { get; set; }
        public sbyte? Age { get; set; }
        public byte[] Photo { get; set; }

        public Credential Credential { get; set; }
        public ICollection<Followers> Blogers { get; set; }
        public ICollection<Followers> Subscribers { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
