using System;
using System.Collections.Generic;

namespace SocialNetwork
{
    public class ProfileDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Location { get; set; }
        public byte? Age { get; set; }
        public string PhotoUrl { get; set; }
    }
}
