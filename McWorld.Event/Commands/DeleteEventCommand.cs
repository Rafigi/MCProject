namespace McWorld.Event.Commands
{
    using McWorld.Shared.Messages;
    using System;

    public class DeleteEventCommand : ICommand
    {
        public DeleteEventCommand(Guid eventId)
        {
            EventId = eventId;
        }

        public Guid EventId { get; set; }
    }
}