namespace McWorld.Shared.Dtos
{
    using McWorld.Shared.Models;
    using System;
    using System.Collections.Generic;

    public class UserDto
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Birthdate { get; set; }
        public string Created { get; set; }

        //ForeignKeys
        public List<Route> Routes { get; set; }
        public List<Event> Events { get; set; }

        //This if to make a many og many relation for the registration
        public ICollection<Registration> Registration { get; set; }

    }
}
