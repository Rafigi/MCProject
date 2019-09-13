using MCAPI.Models;
using MCAPI.Persistence;
using System;
using System.Threading.Tasks;

namespace MCAPI.Commands
{
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
