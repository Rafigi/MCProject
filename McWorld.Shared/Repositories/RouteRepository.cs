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

        public IEnumerable<Route> GetAll()
        {
            return McDbContext.Routes.ToList();
        }

        public Route GetByID(Guid id)
        {
            return McDbContext.Routes.Single(x => x.RouteID == id);
        }


        public IEnumerable<Route> GetRoutesWithSearchCritia(bool motorway, bool ferry, bool toll)
        {
            throw new NotImplementedException();
        }

        public Route GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public McDbContext McDbContext
        {
            get { return _context as McDbContext; }
        }
    }
}
