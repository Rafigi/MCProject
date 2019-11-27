namespace McWorld.Event.Handlers
{
    using McWorld.Event.Commands;
    using McWorld.McRoute.Commands;
    using McWorld.Shared.Factory;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using System.Threading.Tasks;

    public class CreateEventCommandHandler : ICommandHandler<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventFactory _eventFactory;
        private readonly ICommandHandler<CreateRouteCommand> _createRouteCommandHandler;

        public CreateEventCommandHandler(
            IEventRepository eventRepository,
            IEventFactory eventFactory,
            ICommandHandler<CreateRouteCommand> createRouteCommandHandler
            )
        {
            _eventRepository = eventRepository;
            _eventFactory = eventFactory;
            _createRouteCommandHandler = createRouteCommandHandler;
        }

        public Task ExecuteAsync(CreateEventCommand message)
        {
            var @event = _eventFactory.Create(message.Event);
            _eventRepository.Add(@event);

            _createRouteCommandHandler.ExecuteAsync(new CreateRouteCommand(message.Route));
            return Task.CompletedTask;
        }
    }
}