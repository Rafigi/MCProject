namespace McWorld.Shared.Repository
{
    using McWorld.Shared.Data;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class RouteRepository : Repository<Route>, IRouteRepository
    {
        public RouteRepository(McDbContext mcDbContext) : base(mcDbContext)
        {
        }

        public IEnumerable<Route> GetAllRoutes()
        {
            return McDbContext.Routes.ToList();
        }

        public Route GetRouteByID(Guid id)
        {
            return McDbContext.Routes.Single(x => x.RouteID == id);
        }

        public string GetRouteDistance(Guid id)
        {
            return McDbContext.Routes.Single(x => x.RouteID == id).Distance;
        }

        public IEnumerable<Route> GetRoutesWithSearchCritia(bool motorway, bool ferry, bool toll)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Route> GetUserCreatedRoutesByID(Guid id)
        {
            return McDbContext.Routes.Where(x => x.User.UserID == id);
        }

        public McDbContext McDbContext
        {
            get { return _context as McDbContext; }
        }
    }
}
