using System;
using System.Collections.Generic;

namespace SocialNetwork
{
    public partial class Followers
    {
        public int IdBloger { get; set; }
        public int IdSubscriber { get; set; }

        public Profile Bloger { get; set; }
        public Profile Subscriber{ get; set; }
    }
}
