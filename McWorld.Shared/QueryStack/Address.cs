using System;
using System.Collections.Generic;

namespace McWorld.Shared.QueryStack
{
    public partial class Address
    {
        public Guid AddressId { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Guid RouteId { get; set; }

        public virtual Routes Route { get; set; }
    }
}
