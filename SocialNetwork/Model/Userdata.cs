using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork
{
    public partial class Userdata
    {

        public int IdProfile { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public byte? Gender { get; set; }
        public string Location { get; set; }
        public int? Age { get; set; }

        public Profile ProfileNavigation { get; set; }

    }
}
