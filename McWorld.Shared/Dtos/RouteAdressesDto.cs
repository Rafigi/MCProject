using McWorld.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace McWorld.Shared.Dtos
{
    public class RouteAdressesDto
    {
        //Who Created the Route
        string Username { get; set; }

        public Guid RouteID { get; set; }
        public double Distance { get; set; }

        public bool Motorway { get; set; }

        public bool Ferry { get; set; }

        public bool Toll { get; set; }

        public string Created { get; set; }

        //There must be more then 1 address on a route
        public List<Address> Addresses { get; set; }
    }
}
