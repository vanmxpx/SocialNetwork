﻿using System;
using System.Collections.Generic;

namespace SocialNetwork
{
    public class Followers
    {
        public int BlogerRef { get; set; }
        public Profile Bloger { get; set; }
        
        public int SubscriberRef { get; set; }
        public Profile Subscriber{ get; set; }
    }
}
