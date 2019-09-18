namespace MCAPI.McWorld.Shared.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Route
    {
        [Key]
        public Guid RouteID { get; set; }
        [Required]
        public double Distance { get; set; }
        [Required]
        public bool Motorway { get; set; }
        [Required]
        public bool Ferry { get; set; }
        [Required]
        public bool Toll { get; set; }
        [Required]
        public string Created { get; set; }

        //ForeignKeys! Types have to be there!
        public Guid? UserID { get; set; }
        public User User { get; set; }
        public Guid AddressID { get; set; }
        public Address Address { get; set; }

        //A One to many relationship
        public List<Event> Events { get; set; }
    }
}
