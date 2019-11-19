namespace McWorld.Shared.Queryables
{
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

        public IQueryable<Events> GetAll()
        {
            return _queryContext.Events;
        }

        public Events GetById(Guid id)
        {
            return _queryContext.Events.Single(i => i.EventId == id);
        }

        public IQueryable<Events> GetRegistrated(Guid UserId)
        {
            return _queryContext.Events.Include(i => i.Registration)
                .Where(i => i.Registration.Any(W => W.UserId == UserId));
        }

        public IQueryable<Events> GetByUser(Guid UserId)
        {
            return _queryContext.Events.Where(i => i.UserId == UserId);
        }
    }
}
