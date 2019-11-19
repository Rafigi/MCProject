namespace McWorld.Shared.Queryables
{
    using McWorld.Shared.QueryStack;
    using System;
    using System.Linq;

    public interface IEventQueryables
    {
        Events GetById(Guid id);
        IQueryable<Events> GetAll();
        IQueryable<Events> GetByUser(Guid UserId);
        IQueryable<Events> GetRegistrated(Guid UserId);
    }
}
