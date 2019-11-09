using System;
using System.Collections.Generic;

namespace McWorld.Shared.QueryStack
{
    public partial class Routes
    {
        public Routes()
        {
            Address = new HashSet<Address>();
            Events = new HashSet<Events>();
        }

        public Guid RouteId { get; set; }
        public string Distance { get; set; }
        public bool Motorway { get; set; }
        public bool Ferry { get; set; }
        public bool Toll { get; set; }
        public string Created { get; set; }
        public Guid? UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Events> Events { get; set; }
    }
}
