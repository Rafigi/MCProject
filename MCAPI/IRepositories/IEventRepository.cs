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
        Event GetEventByID(int id);
        IEnumerable<Event> GetEventsCreatedByUser(int id);
    }
}
