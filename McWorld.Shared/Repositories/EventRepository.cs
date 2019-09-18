namespace MCAPI.McWorld.Shared.Repository
{
    using MCAPI.McWorld.Shared.Data;
    using MCAPI.McWorld.Shared.IRepository;
    using MCAPI.McWorld.Shared.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(McDbContext context) : base(context)
        {
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return McDbContext.Events.ToList();
        }

        public Event GetEventByID(Guid id)
        {
            return McDbContext.Events.Single(x => x.EventID == id);
        }

        public IEnumerable<Event> GetEventsCreatedByUser(Guid id)
        {
            return McDbContext.Events.Where(x => x.User.UserID == id).ToList();
        }

        public McDbContext McDbContext
        {
            get { return _context as McDbContext; }
        }
    }
}
