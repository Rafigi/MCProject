using System;
using System.Collections.Generic;

namespace McWorld.Shared.QueryStack
{
    public partial class Users
    {
        public Users()
        {
            Events = new HashSet<Events>();
            Registration = new HashSet<Registration>();
            Routes = new HashSet<Routes>();
        }

        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Birthdate { get; set; }
        public string Created { get; set; }

        public virtual ICollection<Events> Events { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }
        public virtual ICollection<Routes> Routes { get; set; }
    }
}
