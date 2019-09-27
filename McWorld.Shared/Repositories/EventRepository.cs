namespace McWorld.Shared.Repository
{
    using McWorld.Shared.Data;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
