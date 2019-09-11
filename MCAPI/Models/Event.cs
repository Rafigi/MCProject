using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCAPI.Models
{
    public class Event
    {
        public Event()
        {

        }
        public Event(Guid eventId, 
            string headline, 
            string description, 
            string startDate, 
            string startTime, 
            string endDate, 
            string endTime,
            int registrationCount, 
            string created, 
            Guid routeID, 
            Guid? userID)
        {
            EventID = eventId;
            Headline = headline;
            Description = description;
            StartDate = startDate;
            StartTime = startTime;
            EndDate = endDate;
            EndTime = endTime;
            RegistrationCount = registrationCount;
            Created = Created;
            RouteID = routeID;
            UserID = userID;
        }
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

        //ForeignKeys
        public Guid? UserID { get; set; }
        public User User { get; set; }
        public Guid RouteID { get; set; }
        public Route Route { get; set; }

        //Is there to make a many og many relation for the registration
        public ICollection<Registration> Registration { get; set; }
    }
}
