namespace McWorld.Event.Commands
{
    using McWorld.Shared.Messages;
    using System;

    public class UnRegisterUserOnEventCommand : ICommand
    {
        public UnRegisterUserOnEventCommand(Guid eventId, Guid? userId)
        {
            EventId = eventId;
            UserId = userId;
        }

        public Guid EventId { get; set; }
        public Guid? UserId { get; private set; }
    }
}
