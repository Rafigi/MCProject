namespace McWorld.Event.Handlers
{
    using McWorld.Event.Commands;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using System;
    using System.Threading.Tasks;

    public class DeleteEventCommandHandler : ICommandHandler<DeleteEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public DeleteEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task ExecuteAsync(DeleteEventCommand message)
        {
            //Using the repostory, because the remove method need Event Type nad not EventDto Type.
            var @event = _eventRepository.GetById(message.EventId);
            if (@event == null)
                throw new ArgumentNullException($"There is no event with the ID {message.EventId}");

            _eventRepository.Remove(@event);
            return Task.CompletedTask;
        }
    }
}
