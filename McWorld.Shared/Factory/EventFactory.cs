namespace McWorld.Shared.Factory
{
    using McWorld.Shared.Models;
    using System;
    using System.Collections.Generic;

    public class EventFactory : IEventFactory
    {
        private List<Address> _addresses;
        public Event Create(Event @event)
        {
            Guid _routeID = Guid.NewGuid();

            //Creating all the addresses, there are connected to the route
            foreach (var Address in @event.Route.Addresses)
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
                    Longitude = Address.Longitude,
                }); 
            }

            return new Event()
            {
                EventID = Guid.NewGuid(),
                Headline = @event.Headline,
                Description = @event.Description,
                Created = @event.Created,
                UserID = @event.UserID,
                StartDate = @event.StartDate,
                StartTime = @event.StartTime,
                EndDate = @event.EndDate,
                EndTime = @event.EndTime,
                RouteID = _routeID,

                Route = new Route()
                {
                    RouteID = _routeID,
                    Created = @event.Route.Created,
                    Distance = @event.Route.Distance,
                    Ferry = @event.Route.Ferry,
                    Motorway = @event.Route.Motorway,
                    Toll = @event.Route.Toll,
                    UserID = @event.Route.UserID,
                    Addresses = _addresses
                }
            };
        }

        public Event Update(Event type)
        {
            throw new NotImplementedException();
        }
    }
}
