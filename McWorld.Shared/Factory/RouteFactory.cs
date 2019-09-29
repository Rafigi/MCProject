namespace McWorld.Shared.Factory
{
    using McWorld.Shared.Models;
    using System;
    using System.Collections.Generic;

    public class RouteFactory : IRouteFactory
    {
        private List<Address> _addresses;
        public Route Create(Route route)
        {
            //Creating all the addresses, there are connected to the route
            foreach (var Address in route.Addresses)
            {
                _addresses.Add(new Address()
                {
                    AddressId = Guid.NewGuid(),
                    StreetName = Address.StreetName,
                    StreetNumber = Address.StreetNumber,
                    City = Address.City,
                    Country = Address.Country,
                    Zipcode = Address.Zipcode,
                    Latitude = Address.Latitude,
                    Longitude = Address.Longitude
                });
                
            }

            Guid _routeID = Guid.NewGuid();
            //Creating Route with a new ID, and setting all the addresses on this route.
            var _route = new Route()
            {
                RouteID = _routeID,
                Distance = route.Distance,
                Created = new DateTime().ToShortDateString(),
                Ferry = route.Ferry,
                Toll = route.Toll,
                Motorway = route.Motorway,
                UserID = route.UserID,
                Events = null,
                Addresses = _addresses
            };

            return _route;
        }


        public Route Update(Route route)
        {
            throw new NotImplementedException();
        }
    }
}
