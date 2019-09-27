namespace McWorld.Shared.Queryables
{
    using McWorld.Shared.Dtos;
    using System;
    using System.Collections.Generic;
    public interface IQueryables
    {
        IEnumerable<RouteDto> GetAllRoutesWithAddress();
        IEnumerable<EventDto> GetAllEventsWithRoutes();
        IEnumerable<EventDto> GetAllUserCreatedEvents(Guid userId);
        IEnumerable<RouteDto> GetAllUserCreatedRoutes(Guid userId);
        IEnumerable<RegistrationDto> GetAllUserRegisteredEvents();
    }
}
