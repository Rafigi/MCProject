namespace McWorld.Route.Handlers
{
    using McWorld.Route.Commands;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using McWorld.Shared.Queryables;
    using System.Threading.Tasks;
    using System;

    class UpdateRouteCommandHandler : ICommandHandler<UpdateRouteCommand>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IRouteQueryables _routeQueryables;

        public UpdateRouteCommandHandler(IRouteRepository routeRepository, IRouteQueryables routeQueryables)
        {
            _routeRepository = routeRepository;
            _routeQueryables = routeQueryables;
        }
        public Task ExecuteAsync(UpdateRouteCommand message)
        {
            if (_routeQueryables.GetById(message.Route.RouteID) != null)
                throw new ArgumentNullException($"There is already a route with the ID {message.Route.RouteID}");


            _routeRepository.Update(message.Route);
            return Task.CompletedTask;
        }
    }
}
