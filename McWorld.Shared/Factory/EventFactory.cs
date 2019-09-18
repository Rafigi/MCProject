namespace MCAPI.McWorld.Shared.Factory
{
    using MCAPI.McWorld.Shared.Models;
    using System;
    public class EventFactory : IEventFactory
    {
        public Event Create(Event @event)
        {
            Guid routeID = Guid.NewGuid();
            Guid addressID = Guid.NewGuid();

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
                RouteID = routeID,

                Route = new Route()
                {
                    RouteID = Guid.NewGuid(),
                    AddressID = addressID,
                    Created = @event.Route.Created,
                    Distance = @event.Route.Distance,
                    Ferry = @event.Route.Ferry,
                    Motorway = @event.Route.Motorway,
                    Toll = @event.Route.Toll,
                    UserID = @event.Route.UserID,

                    Address = new Address()
                    {
                        AddressID = addressID,
                        StreetName = @event.Route.Address.StreetName,
                        StreetNumber = @event.Route.Address.StreetNumber,
                        City = @event.Route.Address.City,
                        Country = @event.Route.Address.Country,
                        Zipcode = @event.Route.Address.Zipcode,
                        Latitude = @event.Route.Address.Latitude,
                        Longitude = @event.Route.Address.Longitude
                    }
                }
            };
        }

        public Event Update(Event type)
        {
            throw new NotImplementedException();
        }
    }
}
