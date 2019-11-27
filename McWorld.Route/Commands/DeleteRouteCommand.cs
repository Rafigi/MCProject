namespace McWorld.Route.Commands
{
    using McWorld.Shared.Messages;
    using System;

    public class DeleteRouteCommand : ICommand
    {
        public DeleteRouteCommand(Guid routeId)
        {
            RouteId = routeId;
        }

        public Guid RouteId { get; private set; }
    }
}
