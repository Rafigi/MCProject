namespace McWorld.McRoute.Commands
{
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    public class UpdateRouteCommand : ICommand
    {
        public UpdateRouteCommand(Route route)
        {
            Route = route;
        }

        public Route Route { get; private set; }
    }
}
