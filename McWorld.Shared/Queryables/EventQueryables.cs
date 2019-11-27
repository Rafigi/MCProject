namespace McWorld.Shared.Queryables
{
    using McWorld.Shared.Dtos;
    using McWorld.Shared.QueryStack;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EventQueryables : IEventQueryables
    {
        private readonly QueryContext _queryContext;

        public EventQueryables(QueryContext queryContext)
        {
            _queryContext = queryContext;
        }

        public IEnumerable<EventDto> GetAll()
        {
            return _queryContext.Events.Select(e => e.AsDto());
        }

        public EventDto GetById(Guid id)
        {
            return _queryContext.Events.Single(i => i.EventId == id).AsDto();
        }

        public IEnumerable<EventDto> GetUsersRegistered(Guid UserId)
        {
            return _queryContext.Events.Include(i => i.Registration)
                .Where(i => i.Registration.Any(W => W.UserId == UserId)).Select(e => e.AsDto());
        }

        public IEnumerable<EventDto> GetByUser(Guid UserId)
        {
            return _queryContext.Events.Where(u => u.UserId == UserId).Select(e => e.AsDto());
        }
    }
}
