using System;
using System.Collections.Generic;

namespace McWorld.Shared.QueryStack
{
    public partial class Events
    {
        public Events()
        {
            Registration = new HashSet<Registration>();
        }

        public Guid EventId { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public int RegistrationCount { get; set; }
        public string Created { get; set; }
        public Guid? UserId { get; set; }
        public Guid RouteId { get; set; }

        public virtual Routes Route { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }
    }
}
