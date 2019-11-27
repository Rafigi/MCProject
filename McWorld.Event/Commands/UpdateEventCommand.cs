namespace McWorld.McEvent.Commands
{
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;

    public class UpdateEventCommand : ICommand
    {
        public UpdateEventCommand(Event @event)
        {
            Event = @event;
        }

        public Event Event { get; private set; }
    }
}