using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCAPI.Models
{
    public class Address
    {
        public Address()
        {

        }
        public Address(Guid addressID,
            string streetName,
            string streetNumber,
            string city,
            int zipcode,
            string country,
            string latitude,
            string longitude)
        {
            AddressID = addressID;
            StreetName = streetNumber;
            StreetNumber = streetNumber;
            City = city;
            Zipcode = zipcode;
            Country = country;
            Latitude = latitude;
            Longitude = longitude;
        }
        [Key]
        public Guid AddressID { get; set; }
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

        public List<Route> Routes { get; set; }
    }
}
