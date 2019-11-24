namespace McWorld.Route
{
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    public class CreateRouteCommand : ICommand
    {
        public CreateRouteCommand(Route route)
        {
            Route = route;
        }
        public Route Route{ get; private set; }
    }
}
