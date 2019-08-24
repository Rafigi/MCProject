using MCAPI.McContext;
using MCAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.IRepository
{
    public class RouteRepository : Repository<Route>, IRouteRepository
    {
        public RouteRepository(McDbContext mcDbContext) : base(mcDbContext)
        {
        }

        public IEnumerable<Route> GetAllRoutes()
        {
            return McDbContext.Routes.ToList();
        }

        public Route GetRouteByID(int id)
        {
            return McDbContext.Routes.Single(x => x.RouteID == id);
        }

        public double GetRouteDistance(int id)
        {
            return McDbContext.Routes.Single(x => x.RouteID == id).Distance;
        }

        public IEnumerable<Route> GetRoutesWithSearchCritia(bool motorway, bool ferry, bool toll)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Route> GetUserCreatedRoutesByID(int id)
        {
            return McDbContext.Routes.Where(x => x.User.UserID == id);
        }
        
        public McDbContext McDbContext
        {
            get { return _context as McDbContext; }
        }
    }
}
