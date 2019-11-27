namespace McWorld.Shared.Dtos
{
using McWorld.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
    public class RouteDto
    {
        //Who Created the Route
        string Username { get; set; }
        public Guid RouteID { get; set; }
        public string Distance { get; set; }
        public bool Motorway { get; set; }
        public bool Ferry { get; set; }
        public bool Toll { get; set; }
        public string Created { get; set; }

        //There must be more than 1 address on a route
        public List<Address> Addresses { get; set; }
    }
}
