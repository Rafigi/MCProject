namespace McWorld.Route
{
    using McWorld.Shared.Models;
    using McWorld.Shared.Messages;
    using McWorld.Shared.Persistence;
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
            unitOfWork.Routes.Add(Route);
            return Task.CompletedTask;
        }
    }
}
