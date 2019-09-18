namespace MCAPI.McWorld.Shared.IRepository
{
    using MCAPI.McWorld.Shared.Models;
    using System;
    using System.Collections.Generic;
    public interface IRouteRepository : IRepository<Route>
    {
        IEnumerable<Route> GetAllRoutes();
        double GetRouteDistance(Guid id);
        IEnumerable<Route> GetRoutesWithSearchCritia(bool motorway, bool ferry, bool toll);
        IEnumerable<Route> GetUserCreatedRoutesByID(Guid id);
        Route GetRouteByID(Guid id);


    }
}
