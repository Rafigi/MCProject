namespace McWorld.Shared.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// A Event, Where a Route with 2 Addresses is Connected
    /// </summary>
    public class Event
    {
        [Key]
        public Guid EventID { get; set; }
        [Required]
        public string Headline { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndDate { get; set; }
        [Required]
        public string EndTime { get; set; }
        [Required]
        public int RegistrationCount { get; set; }
        [Required]
        public string Created { get; set; }

        //ForeignKeys! The type have to be there!
        public Guid? UserID { get; set; }
        public User User { get; set; }
        public Guid RouteID { get; set; }
        public Route Route { get; set; }

        //Is there to make a many og many relation for the registration
        public ICollection<Registration> Registration { get; set; }
    }
}
