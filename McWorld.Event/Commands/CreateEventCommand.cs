namespace McWorld.Event
{
    using McWorld.Shared.Models;
    using McWorld.Shared.Messages;
    using McWorld.Shared.Persistence;
    using System.Threading.Tasks;
    using System;

    public class CreateEventCommand : ICommand
    {
        public Event Event { get; private set; }

        public CreateEventCommand(Event @event)
        {
            Event = new Event()
            {
                EventID = Guid.NewGuid(),
                Headline = @event.Headline,
                Description = @event.Description,
                Created = @event.Created,
                UserID = @event.UserID,
                StartDate = @event.StartDate,
                StartTime = @event.StartTime,
                EndDate = @event.EndDate,
                EndTime = @event.EndTime,
                RouteID = @event.RouteID
            };
        }

        public Task Execute(IUnitOfWork unitOfWork)
        {
            unitOfWork.Events.Add(Event);
            return Task.CompletedTask;
        }
    }
}
