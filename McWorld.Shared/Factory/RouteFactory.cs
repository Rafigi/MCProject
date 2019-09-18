
namespace MCAPI.McWorld.Shared.Factory
{
    using MCAPI.McWorld.Shared.Models;
    using System;
    public class RouteFactory : IRouteFactory
    {
        public Route Create(Route route)
        {
            var addressID = Guid.NewGuid();

            return new Route()
            {
                RouteID = Guid.NewGuid(),
                AddressID = addressID,
                Created = route.Created,
                Distance = route.Distance,
                Ferry = route.Ferry,
                Motorway = route.Motorway,
                Toll = route.Toll,
                UserID = route.UserID,
                Address = new Address()
                {
                    AddressID = addressID,
                    StreetName = route.Address.StreetName,
                    StreetNumber = route.Address.StreetNumber,
                    City = route.Address.City,
                    Country = route.Address.Country,
                    Zipcode = route.Address.Zipcode,
                    Latitude = route.Address.Latitude,
                    Longitude = route.Address.Longitude
                }
            };
        }

        public Route Update(Route route)
        {
            throw new NotImplementedException();
        }
    }
}
