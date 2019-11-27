namespace McWorld.Event.Commands
{
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;

    public class CreateEventCommand : ICommand
    {
        public CreateEventCommand(Event @event)
        {
            Event = @event;
            Route = @event.Route;
        }

        public Event Event { get; private set; }
        public Route Route { get; private set; }
    }
}