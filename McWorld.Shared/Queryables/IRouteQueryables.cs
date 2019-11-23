namespace McWorld.Shared.Queryables
{
    using McWorld.Shared.Dtos;
    using System;
    using System.Collections.Generic;

    public interface IRouteQueryables
    {
        /// <summary>
        /// Gets the by routeID
        /// Returning null, if not exist.
        /// </summary>
        /// <param name="routeId">The route identifier.</param>
        /// <returns></returns>
        RouteDto GetById(Guid id);
        IEnumerable<RouteDto> GetAll();
        IEnumerable<RouteDto> GetByUser(Guid UserId);
    }
}
