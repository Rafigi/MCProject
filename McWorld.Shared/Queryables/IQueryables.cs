namespace McWorld.Shared.Queryables
{
    using McWorld.Shared.Dtos;
    using System;
    using System.Collections.Generic;
    public interface IQueryables
    {
        IEnumerable<RouteAdressesDto> GetAllRoutesWithAddress();
        IEnumerable<EventRouteDto> GetAllEventsWithRoutes();
        IEnumerable<EventRouteDto> GetAllUserCreatedEvents(Guid userId);
        IEnumerable<RouteAdressesDto> GetAllUserCreatedRoutes(Guid userId);
        IEnumerable<RegistrationDto> GetAllUserRegisteredEvents();
    }
}
