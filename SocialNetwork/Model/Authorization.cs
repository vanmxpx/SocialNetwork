﻿using System;
using System.Collections.Generic;

namespace SocialNetwork
{
    public class Authorization
    {
        public int Id { get; set; }
        public string SystemStatus { get; set; }
        public DateTime DatetimeStart { get; set; }
        public DateTime DatetimeRequest { get; set; }

        public int CredentialRef { get; set; }
        public Credential Credential { get; set; }
    }
}
