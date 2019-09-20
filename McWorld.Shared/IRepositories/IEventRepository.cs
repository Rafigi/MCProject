﻿namespace McWorld.Shared.IRepository
{
    using McWorld.Shared.Models;
    using System;
    using System.Collections.Generic;
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetAllEvents();
        Event GetEventByID(Guid id);
        IEnumerable<Event> GetEventsCreatedByUser(Guid id);
    }
}