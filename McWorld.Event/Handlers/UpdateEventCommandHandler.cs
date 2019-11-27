namespace McWorld.Event.Handlers
{
    using McWorld.Event.Commands;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using McWorld.Shared.Queryables;
    using System;
    using System.Threading.Tasks;

    public class UpdateEventCommandHandler : ICommandHandler<UpdateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventQueryables _eventQueryables;

        public UpdateEventCommandHandler(IEventRepository eventRepository, IEventQueryables eventQueryables)
        {
            _eventRepository = eventRepository;
            _eventQueryables = eventQueryables;
        }

        public Task ExecuteAsync(UpdateEventCommand message)
        {
            if (_eventQueryables.GetById(message.Event.EventID) == null)
                throw new ArgumentNullException($"There is no event with the ID {message.Event.EventID}");


            _eventRepository.Update(message.Event);
            return Task.CompletedTask;
        }
    }
}
