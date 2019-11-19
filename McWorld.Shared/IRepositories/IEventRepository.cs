namespace McWorld.Shared.IRepository
{
    using McWorld.Shared.Models;
    using System;
    using System.Collections.Generic;
    public interface IEventRepository : IRepository<Event>
    {
        Event GetById(Guid id);
    }
}
