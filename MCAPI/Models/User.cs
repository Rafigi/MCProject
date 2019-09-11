using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCAPI.Models
{
    public class User
    {
        public User()
        {


        }
        public User
            (
            Guid userID,
            string username,
            string password,
            string email,
            string birthdate,
            string created
            )
        {
            UserID = userID;
            Username = username;
            Password = password;
            Email = email;
            Birthdate = birthdate;
            Created = created;
        }
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
       
    }
}
