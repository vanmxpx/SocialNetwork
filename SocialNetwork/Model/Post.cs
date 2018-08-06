﻿using System;
using System.Collections.Generic;

namespace SocialNetwork
{
    public partial class Post
    {
        public long Id { get; set; }
        public int ProfileRef { get; set; }
        public string Text { get; set; }
        public DateTime Datetime { get; set; }

        public Profile Profile { get; set; }
    }
}
