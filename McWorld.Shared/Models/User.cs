namespace McWorld.Shared.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// This is an Object for the User, There have connections to Route, Event, Registration
    /// </summary>
    public partial class User
    {
        [Key]
        public Guid UserID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        [Required]
        public string Birthdate { get; set; }
        public string Created { get; set; }

        //ForeignKeys
        public List<Route> Routes { get; set; }
        public List<Event> Events { get; set; }

        //This if to make a many og many relation for the registration
        public ICollection<Registration> Registration { get; set; }


        #region Methods
        public void UpdateMail(string mail)
        {
            Email = mail;
        }

        public void UpdatePassword(string password)
        {
            Password = password;
        }

        #endregion


    }
}
