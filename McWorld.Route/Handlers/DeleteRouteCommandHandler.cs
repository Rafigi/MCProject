namespace McWorld.Route.Handlers
{
    using McWorld.Route.Commands;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using McWorld.Shared.Queryables;
    using System.Threading.Tasks;
    using System;

    class DeleteRouteCommandHandler : ICommandHandler<DeleteRouteCommand>
    {
        private readonly IRouteRepository _routeRepository;

        public DeleteRouteCommandHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }
        public Task ExecuteAsync(DeleteRouteCommand message)
        {
            var route = _routeRepository.GetById(message.RouteId);
            if (route == null)
                throw new ArgumentNullException($"There is no route with the ID {message.RouteId}");

            _routeRepository.Remove(route);
            return Task.CompletedTask;
        }
    }
}
