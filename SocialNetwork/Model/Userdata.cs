﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork
{
        public enum Gender : byte {
      Male = 0,
      Female = 1,
      Other = 2
}
    public partial class Userdata
    {

        public int IdProfile { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Location { get; set; }
        public byte? Age { get; set; }

        public Profile ProfileNavigation { get; set; }

    }
}
