namespace MCAPI.McWorld.Route
{
    using MCAPI.McWorld.Shared.Models;
    using MCAPI.McWorld.Shared.Messages;
    using MCAPI.McWorld.Shared.Persistence;
    using System.Threading.Tasks;
    public class CreateRouteCommand : ICommand
    {
        public Route Route { get; private set; }

        public CreateRouteCommand(Route route)
        {
            Route = new Route()
            {
                RouteID = route.RouteID,
                AddressID = route.AddressID,
                Created = route.Created,
                Distance = route.Distance,
                Ferry = route.Ferry,
                Motorway = route.Motorway,
                Toll = route.Toll,
                UserID = route.UserID
            };
        }

        public Task Execute(IUnitOfWork unitOfWork)
        {
            return Task.CompletedTask;
        }
    }
}
