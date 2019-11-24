namespace McWorld.Shared.Repository
{
    using McWorld.Shared.Data;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(McDbContext context) : base(context)
        {
        }

        public IEnumerable<Event> GetCreatedByUser(Guid id)
        {
            return McDbContext.Events.Where(x => x.User.UserID == id).ToList();
        }

        public Event GetById(Guid id)
        {
            return McDbContext.Events.SingleOrDefault(x => x.EventID == id);
        }

        public McDbContext McDbContext
        {
            get { return _context as McDbContext; }
        }
    }
}
