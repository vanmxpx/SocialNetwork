using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork
{
    public partial class Followers
    {
        public int IdProfileBloger { get; set; }
        public int IdProfileSubscriber { get; set; }

        public Profile IdProfileBlogerNavigation { get; set; }
        public Profile IdProfileSubscriberNavigation { get; set; }
    }
}
