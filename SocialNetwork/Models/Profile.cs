using System;
using System.Collections.Generic;

namespace SocialNetwork.Models
{
    public class Profile
    {
        public Profile()
        {
            Bloggers = new HashSet<Followings>();
            Subscribers = new HashSet<Followings>();
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

        public int CredenitialRef { get; set; }

        public ICollection<Followings> Bloggers { get; set; }
        public ICollection<Followings> Subscribers { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
