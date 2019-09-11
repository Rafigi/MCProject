using MCAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.IRepository
{
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetAllEvents();
        Event GetEventByID(Guid id);
        IEnumerable<Event> GetEventsCreatedByUser(Guid id);
    }
}
