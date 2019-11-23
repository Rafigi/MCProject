using McWorld.Shared.Dtos;

namespace McWorld.Shared.QueryStack
{
    public partial class Events
    {
        public EventDto AsDto()
        {
            return new EventDto()
            {
                EventID = EventId,
                Headline = Headline,
                Description = Description,
                StartTime = StartTime,
                StartDate = StartDate,
                EndTime = EndTime,
                EndDate = EndDate
            };
        }

    }
}
