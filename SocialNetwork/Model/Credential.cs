using System;
using System.Collections.Generic;

namespace SocialNetwork
{
    public partial class Credential
    {
        public Credential()
        {
            Authorizations = new HashSet<Authorization>();
        }

        public int Id { get; set; }
        public int ProfileRef { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateRigistration { get; set; }

        public Profile Profile { get; set; }
        public ICollection<Authorization> Authorizations { get; set; }
    }
}
