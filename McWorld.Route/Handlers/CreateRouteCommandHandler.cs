namespace McWorld.Route.Handlers
{
    using McWorld.Address.Commands;
    using McWorld.Route.Commands;
    using McWorld.Shared.Factory;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using System.Threading.Tasks;
    public class CreateRouteCommandHandler : ICommandHandler<CreateRouteCommand>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IRouteFactory _routeFactory;
        private readonly ICommandHandler<CreateAddressCommand> _createAddressCommandHandler;

        public CreateRouteCommandHandler(
            IRouteRepository routeRepository,
            IRouteFactory routeFactory,
            ICommandHandler<CreateAddressCommand> createAddressCommandHandler)
        {
            _routeRepository = routeRepository;
            _routeFactory = routeFactory;
            _createAddressCommandHandler = createAddressCommandHandler;
        }

        public Task ExecuteAsync(CreateRouteCommand message)
        {
            var route = _routeFactory.Create(message.Route);
            _routeRepository.Add(route);
            _createAddressCommandHandler.ExecuteAsync(new CreateAddressCommand(message.Route.Addresses));
            return Task.CompletedTask;
        }
    }
}
