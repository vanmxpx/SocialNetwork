using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork
{
    public partial class Post
    {
        public long Id { get; set; }
        public int IdProfile { get; set; }
        public string Text { get; set; }
        public DateTime Datetime { get; set; }

        public Profile IdProfileNavigation { get; set; }
    }
}
