using MCAPI.Models;
using System;

namespace MCAPI.Commands
{
    public class CreateRouteCommand : ICommand
    {
        public Route Route { get; private set; }

        public CreateRouteCommand(Guid addressID, Route route)
        {
            Route = new Route()
            {
                RouteID = Guid.NewGuid(),
                AddressID = addressID,
                Created = route.Created,
                Distance = route.Distance,
                Ferry = route.Ferry,
                Motorway = route.Motorway,
                Toll = route.Toll,
                UserID = route.UserID
            };
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
