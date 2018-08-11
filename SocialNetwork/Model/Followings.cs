using System;
using System.Collections.Generic;

namespace SocialNetwork
{
    public class Followings
    {
        public int BloggerRef { get; set; }
        public Profile Blogger { get; set; }
        
        public int SubscriberRef { get; set; }
        public Profile Subscriber{ get; set; }
    }
}
