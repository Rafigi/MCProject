namespace McWorld.Shared.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string StreetNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int Zipcode { get; set; }
        [Required]
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        //public int AddressNumber { get; set; } Maybe later with this input

    }
}
