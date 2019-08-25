using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MCAPI.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        public string Birthdate { get; set; }
        [Required]
        public string Created { get; set; }

        //Is there to make a many og many relation for the registration
        public ICollection<Registration> Registration { get; set; }

    }
}
