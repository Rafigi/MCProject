namespace McWorld.Shared.Queryables
{
    using McWorld.Shared.Dtos;
    using System;
    using System.Collections.Generic;

    public interface IEventQueryables
    {
        EventDto GetById(Guid id);
        IEnumerable<EventDto> GetAll();
        IEnumerable<EventDto> GetByUser(Guid UserId);
        IEnumerable<EventDto> GetRegistrated(Guid UserId);
    }
}
