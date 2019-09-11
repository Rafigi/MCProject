using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCAPI.Models
{
    public class Route
    {
        public Route()
        {

        }
        public Route(Guid routeID, Guid addressID, double distance, bool motorWay, bool ferry, bool toll, string created, Guid? userID)
        {
            RouteID = routeID;
            AddressID = addressID;
            Distance = distance;
            Motorway = motorWay;
            Ferry = ferry;
            Toll = toll;
            Created = created;
            UserID = userID;
        }
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

        //ForeignKeys
        public Guid? UserID { get; set; }
        public User User { get; set; }
        public Guid AddressID { get; set; }
        public Address Address { get; set; }
        public List<Event> Events { get; set; }
    }
}
