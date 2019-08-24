using MCAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.IRepository
{
    public interface IRouteRepository : IRepository<Route>
    {
        IEnumerable<Route> GetAllRoutes();
        double GetRouteDistance(int id);
        IEnumerable<Route> GetRoutesWithSearchCritia(bool motorway, bool ferry, bool toll);
        IEnumerable<Route> GetUserCreatedRoutesByID(int id);
        Route GetRouteByID(int id);


    }
}
