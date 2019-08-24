using MCAPI.McContext;
using MCAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.IRepository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(McDbContext context) : base(context)
        {
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return McDbContext.Events.ToList();
        }

        public Event GetEventByID(int id)
        {
            return McDbContext.Events.Single(x => x.EventID == id);
        }

        public IEnumerable<Event> GetEventsCreatedByUser(int id)
        {
            return McDbContext.Events.Where(x => x.User.UserID == id).ToList();
        }

        public McDbContext McDbContext
        {
            get { return _context as McDbContext; }
        }
    }
}
