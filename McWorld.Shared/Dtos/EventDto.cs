using McWorld.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace McWorld.Shared.Dtos
{
    public class EventDto
    {
        public Guid EventID { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public int RegistrationCount { get; set; }
        public string EventCreated { get; set; }

        //The username of who created the event
        public string EventUsername { get; set; }

        //Is the user registreted for the event
        public bool IsUserRegistered { get; set; }

        //There is only one route to an event
        public Route Route { get; set; }

        //There have to be minimum 2 addresses for at route.


    }
}
