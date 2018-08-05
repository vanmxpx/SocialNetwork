﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork
{
    public partial class Authorization
    {
        public long Id { get; set; }
        public int IdProfile { get; set; }
        public int SystemStatus { get; set; }
        public DateTime? DatetimeStart { get; set; }
        public DateTime? DatetimeRequest { get; set; }

        public Profile IdProfileNavigation { get; set; }
    }
}